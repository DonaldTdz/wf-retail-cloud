using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WF.RetailCloud.DingTalk.Organizations
{
    [Table("Organizations")]
    public class Organization : Entity<long> //注意修改主键Id数据类型
    {
        /// <summary>
        /// 部门名称
        /// </summary>
        [StringLength(100)]
        [Required]
        public virtual string DepartmentName { get; set; }
        /// <summary>
        /// 父部门Id（外键）
        /// </summary>
        public virtual long? ParentId { get; set; }
        /// <summary>
        /// 父部门中的次序值
        /// </summary>
        public virtual long? Order { get; set; }
        /// <summary>
        /// 是否隐藏部门
        /// </summary>
        public virtual bool? DeptHiding { get; set; }
        /// <summary>
        /// 企业群群主
        /// </summary>
        [StringLength(100)]
        public virtual string OrgDeptOwner { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Required]
        public virtual DateTime CreationTime { get; set; }
    }

}

