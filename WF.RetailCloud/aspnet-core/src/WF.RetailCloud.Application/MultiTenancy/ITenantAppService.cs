using Abp.Application.Services;
using Abp.Application.Services.Dto;
using WF.RetailCloud.MultiTenancy.Dto;

namespace WF.RetailCloud.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}


