using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using WF.RetailCloud.Configuration.Dto;

namespace WF.RetailCloud.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : RetailCloudAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}

