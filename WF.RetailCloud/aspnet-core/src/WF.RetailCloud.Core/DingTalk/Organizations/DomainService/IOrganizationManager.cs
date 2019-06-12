

using System;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;
using WF.RetailCloud.DingTalk.Organizations;


namespace WF.RetailCloud.DingTalk.Organizations.DomainService
{
    public interface IOrganizationManager : IDomainService
    {

        /// <summary>
        /// 初始化方法
        ///</summary>
        void InitOrganization();



		 
      
         

    }
}

