﻿using Abp.Domain.Repositories;
using Abp.Threading;
using WF.RetailCloud.Wechat.Messages;
using WF.RetailCloud.Wechat.Subscribes;
using WF.RetailCloud.Wechat.Users;
using Microsoft.EntityFrameworkCore;
using Senparc.NeuChar.Entities;
using Senparc.NeuChar.MessageHandlers;
using Senparc.Weixin;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.Entities;
using Senparc.Weixin.MP.Entities.Request;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WF.RetailCloud.Wechat.Messages.DomainService
{
    public class WechatMessageManager : RetailCloudDomainServiceBase, IWechatMessageManager
    {
        private readonly IRepository<WechatMessage> _wechatmessageRepository;
        private readonly IRepository<WechatSubscribe> _wechatsubscribeRepository;
        private readonly IRepository<WechatUser, long> _wechatUserRepository;

        private string appId = Config.SenparcWeixinSetting.WeixinAppId;

        public WechatMessageManager(IRepository<WechatMessage> wechatmessageRepository,
            IRepository<WechatSubscribe> wechatsubscribeRepository,
            IRepository<WechatUser, long> wechatUserRepository)
        {
            _wechatmessageRepository = wechatmessageRepository;
            _wechatsubscribeRepository = wechatsubscribeRepository;
            _wechatUserRepository = wechatUserRepository;
        }

        public async Task<IMessageHandlerDocument> GetMessageHandlerAsync(Stream inputStream, PostModel postModel, int maxRecordCount = 0)
        {
            CustomMessageHandler messageHandler = new CustomMessageHandler(inputStream, postModel, maxRecordCount);
            messageHandler.Messages = await GetCustomMessagesAsync();
            messageHandler.OnSubscribe += MessageHandler_OnSubscribe;
            messageHandler.OnUnsubscribe += MessageHandler_OnUnsubscribe;
            messageHandler.DefaultMessageHandlerAsyncEvent = DefaultMessageHandlerAsyncEvent.SelfSynicMethod; //没有重写的异步方法将默认尝试调用同步方法中的代码
            messageHandler.Logger = Logger;

            var cancellationToken = new CancellationToken();//给异步方法使用
            #region 设置消息去重
            //默认已经开启
            //messageHandler.OmitRepeatedMessage = true;
            #endregion
            messageHandler.SaveRequestMessageLog();//记录 Request 日志（可选）
            await messageHandler.ExecuteAsync(cancellationToken); //执行微信处理过程（关键）
            messageHandler.SaveResponseMessageLog();//记录 Response 日志（可选）

            return messageHandler;
        }
        /// <summary>
        /// 获取图文消息
        /// </summary>
        private async Task<CustomMessages> GetCustomMessagesAsync()
        {
            var messages = new CustomMessages();
            //关注图文消息
            var subscribe = await _wechatsubscribeRepository.GetAll().FirstOrDefaultAsync();
            if (subscribe != null)
            {
                switch (subscribe.MsgType)
                {
                    case MsgTypeEnum.文字消息:
                        {
                            messages.SubscribeMsg = subscribe.Content;
                        }
                        break;
                    case MsgTypeEnum.图文消息:
                        {
                            messages.SubscribeArticle = new Article()
                            {
                                Title = subscribe.Title,
                                Description = subscribe.Desc,
                                PicUrl = subscribe.PicLink,
                                Url = subscribe.Url
                            };
                        }
                        break;
                }
            }
            //回复图文消息
            var msgs = await _wechatmessageRepository.GetAll().ToListAsync();
            foreach (var msg in msgs)
            {
                switch (msg.MsgType)
                {
                    case MsgTypeEnum.文字消息:
                        {
                            //关键字
                            if (msg.TriggerType == TriggerTypeEnum.关键字)
                            {
                                messages.KeyWords[msg.KeyWord] = msg.Content;
                            }
                            else//事件
                            {
                                messages.EventKeies[msg.KeyWord] = msg.Content;
                            }
                        }
                        break;
                    case MsgTypeEnum.图文消息:
                        {
                            //关键字
                            if (msg.TriggerType == TriggerTypeEnum.关键字)
                            {
                                messages.KeyWordsPic[msg.KeyWord] = new Article()
                                {
                                    Title = msg.Title,
                                    Description = msg.Desc,
                                    PicUrl = msg.PicLink,
                                    Url = msg.Url
                                };
                            }
                            else//事件
                            {
                                messages.EventKeiesPic[msg.KeyWord] = new Article()
                                {
                                    Title = msg.Title,
                                    Description = msg.Desc,
                                    PicUrl = msg.PicLink,
                                    Url = msg.Url
                                };
                            }
                        }
                        break;
                }
            }
            return messages;
        }
        /// <summary>
        /// 关注公众号
        /// </summary>
        private void MessageHandler_OnSubscribe(object sender, RequestMessageEvent_Subscribe e)
        {
            AsyncHelper.RunSync(async () =>
            {
                try
                {
                    var user = await _wechatUserRepository.GetAll().Where(w => w.OpenId == e.FromUserName).FirstOrDefaultAsync();
                    var wxuser = await UserApi.InfoAsync(appId, e.FromUserName);//获取微信用户信息
                    if (user == null && !string.IsNullOrEmpty(wxuser.unionid))
                    {
                        //如果小程序先授权
                        user = await _wechatUserRepository.GetAll().Where(w => w.UnionId == wxuser.unionid).FirstOrDefaultAsync();
                    }
                    if (user == null)//新增
                    {
                        WechatUser wechatUser = new WechatUser();
                        wechatUser.BindStatus = BindStatus.已关注;
                        wechatUser.BindTime = DateTime.Now;
                        wechatUser.HeadImgUrl = wxuser.headimgurl;
                        wechatUser.Integral = 0;//首次关注获取10积分
                        wechatUser.NickName = wxuser.nickname;
                        wechatUser.OpenId = wxuser.openid;
                        wechatUser.UnionId = wxuser.unionid;
                        wechatUser.UserType = UserType.普通会员;
                        var uid = await _wechatUserRepository.InsertAndGetIdAsync(wechatUser);
                        await CurrentUnitOfWork.SaveChangesAsync();
                    }
                    else//更新
                    {
                        user.BindStatus = BindStatus.已关注;
                        user.HeadImgUrl = wxuser.headimgurl;
                        user.NickName = wxuser.nickname;
                        user.BindTime = DateTime.Now;
                        user.UnionId = wxuser.unionid;
                        if (string.IsNullOrEmpty(user.OpenId))
                        {
                            user.OpenId = wxuser.openid;
                        }

                        await _wechatUserRepository.UpdateAsync(user);
                        await CurrentUnitOfWork.SaveChangesAsync();
                    }
                }
                catch (Exception ex)
                {
                    Logger.ErrorFormat("关注公众号绑定用户异常：{0}", ex);
                }
            });
        }
        /// <summary>
        /// 取消关注
        /// </summary>
        private void MessageHandler_OnUnsubscribe(object sender, RequestMessageEvent_Unsubscribe e)
        {
            AsyncHelper.RunSync(async () =>
            {
                try
                {
                    var user = await _wechatUserRepository.GetAll().Where(w => w.OpenId == e.FromUserName).FirstOrDefaultAsync();
                    if (user != null)//修改状态
                    {
                        user.BindStatus = BindStatus.取消关注;
                        user.UnBindTime = DateTime.Now;
                        await _wechatUserRepository.UpdateAsync(user);
                        await CurrentUnitOfWork.SaveChangesAsync();
                    }
                }
                catch (Exception ex)
                {
                    Logger.ErrorFormat("取消关注公众号异常：{0}", ex);
                }
            });
        }

        public async Task<CustomMessages> GetCustomMessagesAsyncTest()
        {
            var msg = await GetCustomMessagesAsync();
            return msg;
        }
    }
}

