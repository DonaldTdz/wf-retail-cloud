

using System;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;
using WF.RetailCloud.DingTalk.DingTalkConfigs;


namespace WF.RetailCloud.DingTalk.DingTalkConfigs.DomainService
{
    public interface IDingTalkConfigManager : IDomainService
    {

        /// <summary>
        /// 初始化方法
        ///</summary>
        void InitDingTalkConfig();



		 
      
         

    }
}

