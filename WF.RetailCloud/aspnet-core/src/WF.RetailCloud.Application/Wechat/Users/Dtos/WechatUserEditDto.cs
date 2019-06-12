﻿
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;

namespace WF.RetailCloud.Wechat.Users.Dtos
{
    public class WechatUserEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public long? Id { get; set; }         
 
		/// <summary>
		/// NickName
		/// </summary>
		[Required(ErrorMessage="NickName不能为空")]
		public string NickName { get; set; }

		/// <summary>
		/// OpenId
		/// </summary>
		public string OpenId { get; set; }

        public string WxOpenId { get; set; }

        /// <summary>
        /// UnionId
        /// </summary>
        public string UnionId { get; set; }

		/// <summary>
		/// UserType
		/// </summary>
		[Required(ErrorMessage="UserType不能为空")]
		public int UserType { get; set; }

		/// <summary>
		/// UserId
		/// </summary>
		public Guid? UserId { get; set; }

		/// <summary>
		/// UserName
		/// </summary>
		public string UserName { get; set; }

		/// <summary>
		/// Phone
		/// </summary>
		public string Phone { get; set; }

		/// <summary>
		/// HeadImgUrl
		/// </summary>
		public string HeadImgUrl { get; set; }

		/// <summary>
		/// Address
		/// </summary>
		public string Address { get; set; }

		/// <summary>
		/// Integral
		/// </summary>
		public decimal? Integral { get; set; }

		/// <summary>
		/// BindStatus
		/// </summary>
		[Required(ErrorMessage="BindStatus不能为空")]
		public BindStatus BindStatus { get; set; }

		/// <summary>
		/// BindTime
		/// </summary>
		public DateTime? BindTime { get; set; }

		/// <summary>
		/// UnBindTime
		/// </summary>
		public DateTime? UnBindTime { get; set; }

    }
}
