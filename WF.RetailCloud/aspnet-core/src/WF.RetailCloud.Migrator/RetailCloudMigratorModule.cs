using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using WF.RetailCloud.Configuration;
using WF.RetailCloud.EntityFrameworkCore;
using WF.RetailCloud.Migrator.DependencyInjection;

namespace WF.RetailCloud.Migrator
{
    [DependsOn(typeof(RetailCloudEntityFrameworkModule))]
    public class RetailCloudMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public RetailCloudMigratorModule(RetailCloudEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(RetailCloudMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                RetailCloudConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(RetailCloudMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}

