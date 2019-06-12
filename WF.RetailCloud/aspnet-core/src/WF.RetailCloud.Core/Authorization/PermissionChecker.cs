using Abp.Authorization;
using WF.RetailCloud.Authorization.Roles;
using WF.RetailCloud.Authorization.Users;

namespace WF.RetailCloud.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}

