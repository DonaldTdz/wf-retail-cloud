
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using WF.RetailCloud.DingTalk.Employees;

namespace  WF.RetailCloud.DingTalk.Employees.Dtos
{
    public class EmployeeEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }         


        
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
}
