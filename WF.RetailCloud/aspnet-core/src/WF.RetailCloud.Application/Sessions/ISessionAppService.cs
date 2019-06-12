using System.Threading.Tasks;
using Abp.Application.Services;
using WF.RetailCloud.Sessions.Dto;

namespace WF.RetailCloud.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}

