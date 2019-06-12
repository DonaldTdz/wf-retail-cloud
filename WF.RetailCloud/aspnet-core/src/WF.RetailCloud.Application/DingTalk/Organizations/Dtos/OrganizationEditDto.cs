
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using WF.RetailCloud.DingTalk.Organizations;

namespace  WF.RetailCloud.DingTalk.Organizations.Dtos
{
    public class OrganizationEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public long? Id { get; set; }         


        
		/// <summary>
		/// DepartmentName
		/// </summary>
		[Required(ErrorMessage="DepartmentName不能为空")]
		public string DepartmentName { get; set; }



		/// <summary>
		/// ParentId
		/// </summary>
		public long? ParentId { get; set; }



		/// <summary>
		/// Order
		/// </summary>
		public long? Order { get; set; }



		/// <summary>
		/// DeptHiding
		/// </summary>
		public bool? DeptHiding { get; set; }



		/// <summary>
		/// OrgDeptOwner
		/// </summary>
		public string OrgDeptOwner { get; set; }



		/// <summary>
		/// CreationTime
		/// </summary>
		[Required(ErrorMessage="CreationTime不能为空")]
		public DateTime CreationTime { get; set; }




    }
}
