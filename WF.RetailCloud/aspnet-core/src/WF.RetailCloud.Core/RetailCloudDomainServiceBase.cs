using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace WF.RetailCloud
{
    public abstract class RetailCloudDomainServiceBase : DomainService
    {
        protected RetailCloudDomainServiceBase()
        {
            LocalizationSourceName = RetailCloudConsts.LocalizationSourceName;
        }
    }
}

