

using System;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;
using WF.RetailCloud.DataDictionarys;


namespace WF.RetailCloud.DataDictionarys.DomainService
{
    public interface IDataDictionaryManager : IDomainService
    {

        /// <summary>
        /// 初始化方法
        ///</summary>
        void InitDataDictionary();



		 
      
         

    }
}

