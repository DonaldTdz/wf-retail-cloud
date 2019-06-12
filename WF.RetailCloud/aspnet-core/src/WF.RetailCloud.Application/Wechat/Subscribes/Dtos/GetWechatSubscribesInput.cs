
using Abp.Runtime.Validation;
using WF.RetailCloud.Dtos;

namespace WF.RetailCloud.Wechat.Subscribes.Dtos
{
    public class GetWechatSubscribesInput : PagedSortedAndFilteredInputDto, IShouldNormalize
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

