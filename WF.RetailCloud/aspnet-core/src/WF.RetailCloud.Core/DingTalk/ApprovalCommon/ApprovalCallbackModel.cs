using System;
using System.Collections.Generic;
using System.Text;

namespace WF.RetailCloud.DingTalk.ApprovalCommon
{
    public class ApprovalCallbackModel
    {
        public string EventType { get; set; }

        public string ProcessInstanceId { get; set; }

        public string CorpId { get; set; }

        public string CreateTime { get; set; }

        public string FinishTime { get; set; }

        public string Title { get; set; }

        public string Type { get; set; }

        public string StaffId { get; set; }

        public string Url { get; set; }

        public string Result { get; set; }

        public string ProcessCode { get; set; }
    }
}

