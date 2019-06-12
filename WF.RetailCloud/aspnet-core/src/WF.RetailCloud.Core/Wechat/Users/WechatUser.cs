using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WF.RetailCloud.Wechat.Users
{
    [Table("WechatUsers")]
    public class WechatUser : Entity<long> //注意修改主键Id数据类型
    {
        /// <summary>
        /// 微信昵称
        /// </summary>
        [StringLength(50)]
        [Required]
        public virtual string NickName { get; set; }
        /// <summary>
        /// 微信OpenId
        /// </summary>
        [StringLength(50)]
        public virtual string OpenId { get; set; }

        /// <summary>
        /// 小程序openId
        /// </summary>
        public virtual string WxOpenId { get; set; }
        /// <summary>
        /// 开放平台全局Id
        /// </summary>
        [StringLength(50)]
        public virtual string UnionId { get; set; }
        /// <summary>
        /// 用户类型(枚举：普通会员、VIP会员)
        /// </summary>
        [Required]
        public virtual UserType UserType { get; set; }
        /// <summary>
        /// 零售用户 或 营销人员Id 外键
        /// </summary>
        public virtual Guid? UserId { get; set; }
        /// <summary>
        /// 零售用户 或 营销人员 名称 快照
        /// </summary>
        [StringLength(50)]
        public virtual string UserName { get; set; }
        /// <summary>
        /// 绑定手机
        /// </summary>
        [StringLength(20)]
        public virtual string Phone { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        [StringLength(500)]
        public virtual string HeadImgUrl { get; set; }
        /// <summary>
        /// 收货地址
        /// </summary>
        [StringLength(500)]
        public virtual string Address { get; set; }
        /// <summary>
        /// 积分余额
        /// </summary>
        public virtual decimal? Integral { get; set; }
        /// <summary>
        /// 绑定状态(枚举 已绑定、未绑定)
        /// </summary>
        [Required]
        public virtual BindStatus BindStatus { get; set; }
        /// <summary>
        /// 绑定时间
        /// </summary>
        public virtual DateTime? BindTime { get; set; }
        /// <summary>
        /// 解绑时间
        /// </summary>
        public virtual DateTime? UnBindTime { get; set; }
    }

    public enum BindStatus
    {
        已关注 = 1,
        取消关注 = 2
    }

    public enum UserType
    {
        普通会员 = 1,
        VIP会员 = 2
    }
}

