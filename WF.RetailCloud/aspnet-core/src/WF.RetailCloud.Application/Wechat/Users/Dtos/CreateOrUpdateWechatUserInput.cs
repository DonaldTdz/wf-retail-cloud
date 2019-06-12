

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WF.RetailCloud.Wechat.Users.Dtos
{
    public class CreateOrUpdateWechatUserInput
    {
        [Required]
        public WechatUserEditDto WechatUser { get; set; }

    }
}
