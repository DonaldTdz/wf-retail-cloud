

using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using WF.RetailCloud.DataDictionarys;

namespace WF.RetailCloud.DataDictionarys.Dtos
{
    public class DataDictionaryListDto : EntityDto
    {


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
        [Required(ErrorMessage = "CreationTime不能为空")]
        public DateTime CreationTime { get; set; }


        public string GroupName
        {
            get { return Group.ToString(); }
        }




    }
}
