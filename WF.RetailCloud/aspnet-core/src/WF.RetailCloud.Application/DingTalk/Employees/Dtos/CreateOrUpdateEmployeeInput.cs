

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WF.RetailCloud.DingTalk.Employees;

namespace WF.RetailCloud.DingTalk.Employees.Dtos
{
    public class CreateOrUpdateEmployeeInput
    {
        [Required]
        public EmployeeEditDto Employee { get; set; }

    }
}
