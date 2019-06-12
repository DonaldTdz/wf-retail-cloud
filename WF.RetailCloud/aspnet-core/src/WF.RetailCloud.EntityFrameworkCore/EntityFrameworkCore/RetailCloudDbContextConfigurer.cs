using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace WF.RetailCloud.EntityFrameworkCore
{
    public static class RetailCloudDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<RetailCloudDbContext> builder, string connectionString)
        {
            //builder.UseSqlServer(connectionString);
            builder.UseMySql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<RetailCloudDbContext> builder, DbConnection connection)
        {
            //builder.UseSqlServer(connection);
            builder.UseMySql(connection);
        }
    }
}

