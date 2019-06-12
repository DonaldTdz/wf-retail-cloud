using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WF.RetailCloud.DingTalk.DingTalkConfigs
{
    [Table("DingTalkConfigs")]
    public class DingTalkConfig : Entity //注意修改主键Id数据类型
    {
        /// <summary>
        /// 配置分类枚举(公共配置 1、E应用（E应用名称）2)
        /// </summary>
        [Required]
        public virtual DingDingTypeEnum Type { get; set; }
        /// <summary>
        /// code
        /// </summary>
        [StringLength(50)]
        [Required]
        public virtual string Code { get; set; }
        /// <summary>
        /// 配置项
        /// </summary>
        [StringLength(500)]
        public virtual string Value { get; set; }
        /// <summary>
        /// 配置说明
        /// </summary>
        [StringLength(500)]
        public virtual string Remark { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public virtual int? Seq { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public virtual DateTime CreationTime { get; set; }
    }

}

