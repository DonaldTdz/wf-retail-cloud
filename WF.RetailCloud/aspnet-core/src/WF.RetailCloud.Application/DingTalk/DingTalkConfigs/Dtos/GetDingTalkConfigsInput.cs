
using Abp.Runtime.Validation;
using WF.RetailCloud.Dtos;
using WF.RetailCloud.DingTalk.DingTalkConfigs;

namespace WF.RetailCloud.DingTalk.DingTalkConfigs.Dtos
{
    public class GetDingTalkConfigsInput : PagedSortedAndFilteredInputDto, IShouldNormalize
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

