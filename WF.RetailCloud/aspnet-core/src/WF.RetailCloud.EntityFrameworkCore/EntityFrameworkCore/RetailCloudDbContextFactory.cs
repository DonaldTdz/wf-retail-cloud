using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using WF.RetailCloud.Configuration;
using WF.RetailCloud.Web;

namespace WF.RetailCloud.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class RetailCloudDbContextFactory : IDesignTimeDbContextFactory<RetailCloudDbContext>
    {
        public RetailCloudDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<RetailCloudDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            RetailCloudDbContextConfigurer.Configure(builder, configuration.GetConnectionString(RetailCloudConsts.ConnectionStringName));

            return new RetailCloudDbContext(builder.Options);
        }
    }
}

