using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using WF.RetailCloud.Roles.Dto;
using WF.RetailCloud.Users.Dto;

namespace WF.RetailCloud.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}

