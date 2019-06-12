

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WF.RetailCloud.Wechat.Subscribes.Dtos
{
    public class CreateOrUpdateWechatSubscribeInput
    {
        [Required]
        public WechatSubscribeEditDto WechatSubscribe { get; set; }

    }
}
