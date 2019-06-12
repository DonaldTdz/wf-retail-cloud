

using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Abp.Linq;
using Abp.Linq.Extensions;
using Abp.Extensions;
using Abp.UI;
using Abp.Domain.Repositories;
using Abp.Domain.Services;

using WF.RetailCloud;
using WF.RetailCloud.DingTalk.DingTalkConfigs;


namespace WF.RetailCloud.DingTalk.DingTalkConfigs.DomainService
{
    /// <summary>
    /// DingTalkConfig领域层的业务管理
    ///</summary>
    public class DingTalkConfigManager :RetailCloudDomainServiceBase, IDingTalkConfigManager
    {
		
		private readonly IRepository<DingTalkConfig,int> _repository;

		/// <summary>
		/// DingTalkConfig的构造方法
		///</summary>
		public DingTalkConfigManager(
			IRepository<DingTalkConfig, int> repository
		)
		{
			_repository =  repository;
		}


		/// <summary>
		/// 初始化
		///</summary>
		public void InitDingTalkConfig()
		{
			throw new NotImplementedException();
		}

		// TODO:编写领域业务代码



		 
		  
		 

	}
}

