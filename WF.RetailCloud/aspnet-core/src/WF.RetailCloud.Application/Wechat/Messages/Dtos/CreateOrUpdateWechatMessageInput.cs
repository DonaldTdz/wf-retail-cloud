

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WF.RetailCloud.Wechat.Messages.Dtos
{
    public class CreateOrUpdateWechatMessageInput
    {
        [Required]
        public WechatMessageEditDto WechatMessage { get; set; }

    }
}
