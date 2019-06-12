

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
using WF.RetailCloud.DataDictionarys;


namespace WF.RetailCloud.DataDictionarys.DomainService
{
    /// <summary>
    /// DataDictionary领域层的业务管理
    ///</summary>
    public class DataDictionaryManager :RetailCloudDomainServiceBase, IDataDictionaryManager
    {
		
		private readonly IRepository<DataDictionary,int> _repository;

		/// <summary>
		/// DataDictionary的构造方法
		///</summary>
		public DataDictionaryManager(
			IRepository<DataDictionary, int> repository
		)
		{
			_repository =  repository;
		}


		/// <summary>
		/// 初始化
		///</summary>
		public void InitDataDictionary()
		{
			throw new NotImplementedException();
		}

		// TODO:编写领域业务代码



		 
		  
		 

	}
}

