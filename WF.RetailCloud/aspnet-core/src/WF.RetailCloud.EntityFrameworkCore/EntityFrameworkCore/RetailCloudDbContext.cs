using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using WF.RetailCloud.Authorization.Roles;
using WF.RetailCloud.Authorization.Users;
using WF.RetailCloud.MultiTenancy;
using WF.RetailCloud.Wechat.Messages;
using WF.RetailCloud.Wechat.Subscribes;
using WF.RetailCloud.Wechat.Users;
using WF.RetailCloud.DingTalk.DingTalkConfigs;
using WF.RetailCloud.DingTalk.Employees;
using WF.RetailCloud.DingTalk.Organizations;
using WF.RetailCloud.DataDictionarys;

namespace WF.RetailCloud.EntityFrameworkCore
{
    public class RetailCloudDbContext : AbpZeroDbContext<Tenant, Role, User, RetailCloudDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public RetailCloudDbContext(DbContextOptions<RetailCloudDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<WechatMessage> WechatMessages { get; set; }

        public virtual DbSet<WechatSubscribe> WechatSubscribes { get; set; }

        public virtual DbSet<WechatUser> WechatUsers { get; set; }

        public virtual DbSet<DingTalkConfig> DingTalkConfigs { get; set; }

        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<Organization> Organizations { get; set; }

        public virtual DbSet<DataDictionary> DataDictionaries { get; set; }

    }
}

