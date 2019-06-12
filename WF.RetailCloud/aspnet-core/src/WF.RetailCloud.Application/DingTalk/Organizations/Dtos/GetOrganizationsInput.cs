
using Abp.Runtime.Validation;
using WF.RetailCloud.Dtos;
using WF.RetailCloud.DingTalk.Organizations;

namespace WF.RetailCloud.DingTalk.Organizations.Dtos
{
    public class GetOrganizationsInput : PagedSortedAndFilteredInputDto, IShouldNormalize
    {

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
}

