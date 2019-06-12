
using Abp.Runtime.Validation;
using WF.RetailCloud.Dtos;
using WF.RetailCloud.DingTalk.Employees;

namespace WF.RetailCloud.DingTalk.Employees.Dtos
{
    public class GetEmployeesInput : PagedSortedAndFilteredInputDto, IShouldNormalize
    {

        /// <summary>
        /// 模糊搜索使用的关键字
        ///</summary>
        public string Name { get; set; }
        public string DepartId { get; set; }
        public string Mobile { get; set; }

        /// <summary>
        /// 正常化排序使用
        /// </summary>
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Id";
            }
        }

    }

    public class GetBatchDocRoleInput
    {
        public string EmployeeIds { get; set; }
        public string RoleCode { get; set; }

    }
}

