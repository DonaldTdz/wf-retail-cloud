

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WF.RetailCloud.DingTalk.DingTalkConfigs;

namespace WF.RetailCloud.DingTalk.DingTalkConfigs.Dtos
{
    public class CreateOrUpdateDingTalkConfigInput
    {
        [Required]
        public DingTalkConfigEditDto DingTalkConfig { get; set; }

    }
}
