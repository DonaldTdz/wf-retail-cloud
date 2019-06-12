using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WF.RetailCloud.DingTalk.ApprovalCommon
{
    public class SuiteAccessToken
    {
        [DataMember(Order = 0)]
        public string suite_access_token { get; set; }
        [DataMember(Order = 1)]
        public int expires_in { get; set; }
    }
}

