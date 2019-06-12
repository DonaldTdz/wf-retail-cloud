

using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using WF.RetailCloud.DingTalk.DingTalkConfigs;

namespace WF.RetailCloud.DingTalk.DingTalkConfigs.Dtos
{
    public class DingTalkConfigListDto : EntityDto 
    {

        
		/// <summary>
		/// Type
		/// </summary>
		[Required(ErrorMessage="Type不能为空")]
		public DingDingTypeEnum Type { get; set; }



		/// <summary>
		/// Code
		/// </summary>
		[Required(ErrorMessage="Code不能为空")]
		public string Code { get; set; }



		/// <summary>
		/// Value
		/// </summary>
		public string Value { get; set; }



		/// <summary>
		/// Remark
		/// </summary>
		public string Remark { get; set; }



		/// <summary>
		/// Seq
		/// </summary>
		public int? Seq { get; set; }



		/// <summary>
		/// CreationTime
		/// </summary>
		[Required(ErrorMessage="CreationTime不能为空")]
		public DateTime CreationTime { get; set; }


        public string TypeName
        {
            get
            {
                return Type.ToString();
            }
        }




    }
}
