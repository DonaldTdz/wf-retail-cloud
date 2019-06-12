using System.Threading.Tasks;
using Abp.Application.Services;
using WF.RetailCloud.Authorization.Accounts.Dto;

namespace WF.RetailCloud.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}

