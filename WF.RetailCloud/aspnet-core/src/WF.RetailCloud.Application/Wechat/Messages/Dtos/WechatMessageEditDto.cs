﻿
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using WF.RetailCloud.Wechat.Subscribes;

namespace WF.RetailCloud.Wechat.Messages.Dtos
{
    [AutoMapTo(typeof(WechatMessage))]
    public class WechatMessageEditDto : AuditedEntityDto<int?>
    {

        ///// <summary>
        ///// Id
        ///// </summary>
        //public Guid? Id { get; set; }         


        /// <summary>
        /// KeyWord
        /// </summary>
        [Required(ErrorMessage = "KeyWord不能为空")]
        public string KeyWord { get; set; }

        /// <summary>
        /// 消息类型（枚举 文字消息、图文消息）
        /// </summary>
        [Required(ErrorMessage = "MsgType不能为空")]
        public MsgTypeEnum MsgType { get; set; }

        /// <summary>
        /// 触发类型 （枚举 关键字、点击事件）
        /// </summary>
        public TriggerTypeEnum TriggerType { get; set; }

        /// <summary>
        /// Content
        /// </summary>
        //[Required(ErrorMessage="Content不能为空")]
        public string Content { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Desc { get; set; }

        /// <summary>
        /// 图片链接
        /// </summary>
        public string PicLink { get; set; }

        /// <summary>
        /// 文章连接
        /// </summary>
        public string Url { get; set; }


        ///// <summary>
        ///// CreationTime
        ///// </summary>
        //[Required(ErrorMessage="CreationTime不能为空")]
        //public DateTime CreationTime { get; set; }



        ///// <summary>
        ///// CreatorUserId
        ///// </summary>
        //public long? CreatorUserId { get; set; }



        ///// <summary>
        ///// LastModificationTime
        ///// </summary>
        //public DateTime? LastModificationTime { get; set; }



        ///// <summary>
        ///// LastModifierUserId
        ///// </summary>
        //public long? LastModifierUserId { get; set; }




    }
}
