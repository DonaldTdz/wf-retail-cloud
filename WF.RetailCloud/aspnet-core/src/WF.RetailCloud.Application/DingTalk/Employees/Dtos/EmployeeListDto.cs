

using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using WF.RetailCloud.DingTalk.Employees;
using System.Collections.Generic;
using Abp.AutoMapper;

namespace WF.RetailCloud.DingTalk.Employees.Dtos
{
    public class EmployeeListDto : EntityDto<string> 
    {

        
		/// <summary>
		/// Unionid
		/// </summary>
		public string Unionid { get; set; }



		/// <summary>
		/// Name
		/// </summary>
		public string Name { get; set; }



		/// <summary>
		/// Mobile
		/// </summary>
		public string Mobile { get; set; }



		/// <summary>
		/// Email
		/// </summary>
		public string Email { get; set; }



		/// <summary>
		/// Active
		/// </summary>
		public bool? Active { get; set; }



		/// <summary>
		/// Department
		/// </summary>
		public string Department { get; set; }



		/// <summary>
		/// IsLeaderInDepts
		/// </summary>
		public string IsLeaderInDepts { get; set; }



		/// <summary>
		/// Position
		/// </summary>
		public string Position { get; set; }



		/// <summary>
		/// Avatar
		/// </summary>
		public string Avatar { get; set; }



		/// <summary>
		/// HiredDate
		/// </summary>
		public DateTime? HiredDate { get; set; }



		/// <summary>
		/// JobNumber
		/// </summary>
		public string JobNumber { get; set; }



		/// <summary>
		/// CreationTime
		/// </summary>
		[Required(ErrorMessage="CreationTime不能为空")]
		public DateTime CreationTime { get; set; }




    }

    [AutoMapFrom(typeof(Employee))]
    public class DingDingUserDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Position { get; set; }

        public string Avatar { get; set; }

    }

    public class NzTreeNode
    {
        public virtual string title { get; set; }
        public virtual string key { get; set; }
        public virtual bool IsLeaf { get; set; }

        public virtual bool selected { get; set; }

        public virtual List<NzTreeNode> children { get; set; }
    }

    public class EmployeeNzTreeNode : NzTreeNode
    {

        public new List<EmployeeNzTreeNode> children { get; set; }
        //// custom codes
        public bool IsDept { get; set; }
        //// custom codes end
    }
}
