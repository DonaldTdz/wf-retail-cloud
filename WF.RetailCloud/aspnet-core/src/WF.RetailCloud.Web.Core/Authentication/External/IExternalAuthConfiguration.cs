using System.Collections.Generic;

namespace WF.RetailCloud.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}

