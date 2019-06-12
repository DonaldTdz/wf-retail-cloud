using System.Threading.Tasks;
using WF.RetailCloud.Configuration.Dto;

namespace WF.RetailCloud.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}

