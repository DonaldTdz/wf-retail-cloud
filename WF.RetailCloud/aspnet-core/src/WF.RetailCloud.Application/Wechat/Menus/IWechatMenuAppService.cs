using Abp.Application.Services;
using WF.RetailCloud.Dtos;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WF.RetailCloud.Wechat.Menus
{
    public interface IWechatMenuAppService : IApplicationService
    {
        Task<APIResultDto> CreateMenu(GetMenuResultFull fullJson);

        GetMenuResult GetMenu();
    }
}

