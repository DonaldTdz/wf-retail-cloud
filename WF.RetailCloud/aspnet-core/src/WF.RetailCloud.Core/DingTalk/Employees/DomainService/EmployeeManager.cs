

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
using WF.RetailCloud.DingTalk.Employees;
using WF.RetailCloud.Common;
using Senparc.CO2NET.Helpers;
using System.Text;
using Senparc.CO2NET.HttpUtility;

namespace WF.RetailCloud.DingTalk.Employees.DomainService
{
    /// <summary>
    /// Employee领域层的业务管理
    ///</summary>
    public class EmployeeManager : RetailCloudDomainServiceBase, IEmployeeManager
    {

        private readonly IRepository<Employee, string> _repository;

        /// <summary>
        /// Employee的构造方法
        ///</summary>
        public EmployeeManager(
            IRepository<Employee, string> repository
        )
        {
            _repository = repository;
        }


        /// <summary>
        /// 初始化
        ///</summary>
        public void InitEmployee()
        {
            throw new NotImplementedException();
        }

        // TODO:编写领域业务代码


    



    }
}

