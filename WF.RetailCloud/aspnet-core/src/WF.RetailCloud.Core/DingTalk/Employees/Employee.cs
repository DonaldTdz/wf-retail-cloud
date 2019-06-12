using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WF.RetailCloud.DingTalk.Employees
{
    [Table("Employees")]
    public class Employee : Entity<string> //注意修改主键Id数据类型
    {
        /// <summary>
        /// 员工在当前开发者企业账号范围内的唯一标识
        /// </summary>
        [StringLength(200)]
        public virtual string Unionid { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        [StringLength(50)]
        public virtual string Name { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        [StringLength(11)]
        public virtual string Mobile { get; set; }
        /// <summary>
        /// 电子邮箱
        /// </summary>
        [StringLength(100)]
        public virtual string Email { get; set; }
        /// <summary>
        /// 是否激活
        /// </summary>
        public virtual bool? Active { get; set; }
        /// <summary>
        /// 成员所属部门id列表
        /// </summary>
        [StringLength(300)]
        public virtual string Department { get; set; }
        /// <summary>
        /// 在对应的部门中是否为主管，格式{key：部门Id，val: true/false 是/否}
        /// </summary>
        [StringLength(300)]
        public virtual string IsLeaderInDepts { get; set; }
        /// <summary>
        /// 职务信息
        /// </summary>
        [StringLength(100)]
        public virtual string Position { get; set; }
        /// <summary>
        /// 头像url
        /// </summary>
        [StringLength(200)]
        public virtual string Avatar { get; set; }
        /// <summary>
        /// 入职时间
        /// </summary>
        public virtual DateTime? HiredDate { get; set; }
        /// <summary>
        /// 员工工号
        /// </summary>
        [StringLength(100)]
        public virtual string JobNumber { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Required]
        public virtual DateTime CreationTime { get; set; }
    }

}

