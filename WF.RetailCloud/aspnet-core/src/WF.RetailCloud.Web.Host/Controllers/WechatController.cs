using WF.RetailCloud.Configuration;
using WF.RetailCloud.Controllers;
using WF.RetailCloud.Dtos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Senparc.Weixin;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WF.RetailCloud.Web.Host.Controllers
{
    public class WechatController : RetailCloudControllerBase
    {
        public static readonly string Token = Config.SenparcWeixinSetting.Token ?? CheckSignature.Token;//与微信公众账号后台的Token设置保持一致，区分大小写。
        public static readonly string EncodingAESKey = Config.SenparcWeixinSetting.EncodingAESKey;//与微信公众账号后台的EncodingAESKey设置保持一致，区分大小写。
        public static readonly string AppId = Config.SenparcWeixinSetting.WeixinAppId;//与微信公众账号后台的AppId设置保持一致，区分大小写。
        public static readonly string AppSecret = Config.SenparcWeixinSetting.WeixinAppSecret;//与微信公众账号后台的AppId设置保持一致，区分大小写。
                                                                                              //private string host = "http://localhost:21021";
                                                                                              //private string host = "http://hcwx.sayequ.me";
        private string host = "https://wx.hechuangcd.com";
        private readonly IConfigurationRoot _appConfiguration;

        private string UserOpenId
        {
            get
            {
                if (HttpContext.Session.GetString("UserOpenId") == null)
                {
                    return string.Empty;
                }
                return HttpContext.Session.GetString("UserOpenId");
            }
            set
            {
                value = value ?? string.Empty;
                HttpContext.Session.SetString("UserOpenId", value);
            }
        }

        private string UserUnionid
        {
            get
            {
                if (HttpContext.Session.GetString("UserUnionid") == null)
                {
                    return string.Empty;
                }
                return HttpContext.Session.GetString("UserUnionid");
            }
            set
            {
                value = value ?? string.Empty;
                HttpContext.Session.SetString("UserUnionid", value);
            }
        }

        public WechatController(IHostingEnvironment env)
        {
            _appConfiguration = env.GetAppConfiguration();
            host = _appConfiguration["App:ServerRootAddress"];
        }

        private async Task SetUserOpenId(string code)
        {
            if (!string.IsNullOrEmpty(code))
            {
                //如果userId为null 则需要通过code重新获取
                if (string.IsNullOrEmpty(UserOpenId))
                {
                    try
                    {
                        var oauth = await OAuthApi.GetAccessTokenAsync(AppId, AppSecret, code, "authorization_code");
                        UserOpenId = oauth.openid;
                        UserUnionid = oauth.unionid;
                    }
                    catch (Exception ex)
                    {
                        Logger.ErrorFormat("GetAccessTokenAsync Exception:{0}", ex.Message);
                    }
                }
            }
        }

        public IActionResult GetCurrentUserOpenId()
        {
            APIResultDto result = new APIResultDto();
            //UserOpenId = "666666";
            //UserOpenId = "oL5qB1m9WA2oNqtszJOJWrcpErzk";
            if (string.IsNullOrEmpty(UserOpenId))
            {
                result.Code = 901;
                result.Msg = "用户没有登录";
            }
            else
            {
                result.Code = 0;
                result.Msg = "获取成功";
                result.Data = new { openId = UserOpenId, unionid = UserUnionid };
            }
            return Json(result);
        }

        /// <summary>
        /// 获取JS SDK配置
        /// </summary>
        public async Task<IActionResult> GetJsApiConfigAsync(string url)
        {
            var jsApiConfig = await JSSDKHelper.GetJsSdkUiPackageAsync(AppId, AppSecret, url);
            return Json(jsApiConfig);
        }

        [HttpGet]
        public IActionResult Authorization(AuthorizationPageEnum page, string param)
        {
            //UserOpenId = "9A7C8776-A623-473F-AF29-10D3E79A2FAE";
            var url = string.Empty;
            switch (page)
            {
                case AuthorizationPageEnum.PageName: //烟雨课堂
                    {
                        //if (!string.IsNullOrEmpty(UserOpenId))//如果已获取当前openId 直接跳转到个人中心
                        //{
                        //    return Redirect(AuthorizationPageUrl.NewsStudyUrl);
                        //}
                        //url = host + "/Wechat/NewsStudyAsync";
                        //return Redirect(AuthorizationPageUrl.NewsStudyUrl);
                    } break;
                default:
                    {
                        return Redirect("/wechat/index.html");
                    }
            }

            param = param ?? "123";
            var pageUrl = OAuthApi.GetAuthorizeUrl(AppId, url, param, OAuthScope.snsapi_base, "code");
            return Redirect(pageUrl);
        }



    


        /// <summary>
        /// 烟雨课堂
        /// </summary>
        public async Task<IActionResult> NewsStudy(string code, string state)
        {
            await SetUserOpenId(code);

            return Redirect(AuthorizationPageUrl.NewsStudyUrl);
        }
    }

    public enum AuthorizationPageEnum
    {
        PageName = 1
    }

    public class AuthorizationPageUrl
    {
        public static string NewsStudyUrl = "/dzwechat/index.html#/news-study/study";
    }

}

