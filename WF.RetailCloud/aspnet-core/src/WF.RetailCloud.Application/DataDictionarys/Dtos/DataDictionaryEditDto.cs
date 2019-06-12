
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using WF.RetailCloud.DataDictionarys;

namespace  WF.RetailCloud.DataDictionarys.Dtos
{
    public class DataDictionaryEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public int? Id { get; set; }         


        
		/// <summary>
		/// Group
		/// </summary>
		public DataGroupEnum? Group { get; set; }



		/// <summary>
		/// Code
		/// </summary>
		public string Code { get; set; }



		/// <summary>
		/// Value
		/// </summary>
		public string Value { get; set; }



		/// <summary>
		/// Desc
		/// </summary>
		public string Desc { get; set; }



		/// <summary>
		/// Seq
		/// </summary>
		public int? Seq { get; set; }



		/// <summary>
		/// CreationTime
		/// </summary>
		[Required(ErrorMessage="CreationTime不能为空")]
		public DateTime CreationTime { get; set; }




    }
}
