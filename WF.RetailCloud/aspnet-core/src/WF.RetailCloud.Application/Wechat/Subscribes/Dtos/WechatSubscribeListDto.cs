﻿

using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using WF.RetailCloud.Wechat.Subscribes;

namespace WF.RetailCloud.Wechat.Subscribes.Dtos
{
    public class WechatSubscribeListDto : AuditedEntityDto
    {

        
		/// <summary>
		/// MsgType
		/// </summary>
		[Required(ErrorMessage="MsgType不能为空")]
		public MsgTypeEnum MsgType { get; set; }


		/// <summary>
		/// Content
		/// </summary>
		[Required(ErrorMessage="Content不能为空")]
		public string Content { get; set; }


        /// <summary>
        /// 标题
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public virtual string Desc { get; set; }

        /// <summary>
        /// 图片链接
        /// </summary>
        public virtual string PicLink { get; set; }

        /// <summary>
        /// 文章连接
        /// </summary>
        public virtual string Url { get; set; }
    }
}
