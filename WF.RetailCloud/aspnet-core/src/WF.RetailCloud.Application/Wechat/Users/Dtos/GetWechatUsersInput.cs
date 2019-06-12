
using Abp.Runtime.Validation;
using WF.RetailCloud.Dtos;

namespace WF.RetailCloud.Wechat.Users.Dtos
{
    public class GetWechatUsersInput : PagedSortedAndFilteredInputDto, IShouldNormalize
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

        public UserType? Status { get; set; }
    }
}

