using Abp.AutoMapper;
using WF.RetailCloud.Authentication.External;

namespace WF.RetailCloud.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}

