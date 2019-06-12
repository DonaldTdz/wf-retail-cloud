using System;
using System.Collections.Generic;
using System.Text;

namespace WF.RetailCloud.DingTalk
{
    public class DingBase
    {
        public long errcode { get; set; }

        public string errmsg { get; set; }
    }

    public enum DingDingTypeEnum
    {
        公共配置 = 1,
        智能办公 = 2
    }

    public enum DingDingAppEnum
    {
        智能办公 = 2
    }

    public class DingDingConfigCode
    {
        public static string CorpId = "CorpId";

        public static string Appkey = "Appkey";

        public static string Appsecret = "Appsecret";

        public static string AgentID = "AgentID";
    }

    public class DingDingAppConfig
    {
        public string CorpId { get; set; }

        public string Appkey { get; set; }

        public string Appsecret { get; set; }

        public int AgentID { get; set; }
    }
}

