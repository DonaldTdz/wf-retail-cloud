using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace WF.RetailCloud.Common
{
    public class DingMsgs
    {
        public DingMsgs()
        {
            msg = new DingMsg();
        }

        /// <summary>
        /// 应用agentId
        /// </summary>
        public int agent_id { get; set; }

        /// <summary>
        /// 接收者的用户userid列表
        /// </summary>
        public string userid_list { get; set; }

        /// <summary>
        /// 接收者的部门id列表
        /// </summary>
        public string dept_id_list { get; set; }

        /// <summary>
        /// 是否发送给企业全部用户
        /// </summary>
        public bool to_all_user { get; set; }

        /// <summary>
        /// 消息内容
        /// </summary>
        public DingMsg msg { get; set; }
    }

    public class DingMsg
    {
        public DingMsg()
        {
            link = new DingLinkMsg();
            text = new DingTextMsg();
        }

        /// <summary>
        /// 消息类型
        /// </summary>
        public string msgtype { get; set; }

        /// <summary>
        /// 链接消息
        /// </summary>
        public DingLinkMsg link { get; set; }

        /// <summary>
        /// 文本消息
        /// </summary>
        public DingTextMsg text { get; set; }

    }
    /// <summary>
    /// 链接消息
    /// </summary>
    public class DingLinkMsg
    {
        /// <summary>
        /// 消息点击链接地址
        /// </summary>
        public string messageUrl { get; set; }

        /// <summary>
        /// 图片地址
        /// </summary>
        public string picUrl { get; set; }

        /// <summary>
        /// 消息描述
        /// </summary>
        public string text { get; set; }

        /// <summary>
        /// 消息标题
        /// </summary>
        public string title { get; set; }
    }
    public class DingTextMsg
    {

        /// <summary>
        /// 消息内容
        /// </summary>
        public string content { get; set; }
    }

    /// <summary>
    /// 发送工作通知返回结果
    /// </summary>
    public class MessageResponseResult
    {
        public long errcode { get; set; }
        public string errmsg { get; set; }
        public long task_id { get; set; }
    }

    /// <summary>
    /// 获取工作通知发送结果请求参数
    /// </summary>
    public class MessageSendResultRequest
    {
        /// <summary>
        /// E应用的agentid
        /// </summary>
        public long agent_id { get; set; }

        /// <summary>
        /// 异步任务的id
        /// </summary>
        public long task_id { get; set; }
    }

    /// <summary>
    /// 获取工作通知发送结果回调参数
    /// </summary>
    public class MessageSendResultResponse
    {
        /// <summary>
        /// 返回码
        /// </summary>
        public long errcode { get; set; }

        /// <summary>
        /// 对返回码的文本描述内容
        /// </summary>
        public long errmsg { get; set; }

        /// <summary>
        /// 返回内容
        /// </summary>
        public AsyncSendResultDomain send_result { get; set; }

    }

    public class AsyncSendResultDomain
    {

        /// <summary>
        /// 发送失败的用户id
        /// </summary>
        public List<string> failed_user_id_list { get; set; }

        /// <summary>
        /// 因发送消息超过上限而被流控过滤后实际未发送的userid
        /// </summary>
        public List<string> forbidden_user_id_list { get; set; }

        /// <summary>
        /// 无效的部门id
        /// </summary>
        public List<long> invalid_dept_id_list { get; set; }

        /// <summary>
        /// 无效的用户id
        /// </summary>
        public List<string> invalid_user_id_list { get; set; }

        /// <summary>
        /// 已读消息的用户id
        /// </summary>
        public List<string> read_user_id_list { get; set; }

        /// <summary>
        /// 未读消息的用户id
        /// </summary>
        public List<string> unread_user_id_list { get; set; }
    }
}

