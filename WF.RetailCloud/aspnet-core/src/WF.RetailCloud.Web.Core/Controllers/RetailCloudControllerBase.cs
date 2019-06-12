using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace WF.RetailCloud.Controllers
{
    public abstract class RetailCloudControllerBase: AbpController
    {
        protected RetailCloudControllerBase()
        {
            LocalizationSourceName = RetailCloudConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}

