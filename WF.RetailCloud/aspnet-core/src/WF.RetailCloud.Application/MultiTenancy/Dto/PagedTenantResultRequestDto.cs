using Abp.Application.Services.Dto;

namespace WF.RetailCloud.MultiTenancy.Dto
{
    public class PagedTenantResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
    }
}


