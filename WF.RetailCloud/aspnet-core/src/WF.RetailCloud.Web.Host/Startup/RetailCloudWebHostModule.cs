using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using WF.RetailCloud.Configuration;

namespace WF.RetailCloud.Web.Host.Startup
{
    [DependsOn(
       typeof(RetailCloudWebCoreModule))]
    public class RetailCloudWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public RetailCloudWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(RetailCloudWebHostModule).GetAssembly());
        }
    }
}

