
using System;
using System.Data;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using Abp.UI;
using Abp.AutoMapper;
using Abp.Authorization;
using Abp.Linq.Extensions;
using Abp.Domain.Repositories;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using WF.RetailCloud.Wechat.Users.Dtos;
using WF.RetailCloud.Dtos;

namespace WF.RetailCloud.Wechat.Users
{
    /// <summary>
    /// WechatUser应用层服务的接口方法
    ///</summary>
    public interface IWechatUserAppService : IApplicationService
    {
        /// <summary>
		/// 获取WechatUser的分页列表信息
		///</summary>
        Task<PagedResultDto<WechatUserListDto>> GetPaged(GetWechatUsersInput input);


        /// <summary>
        /// 通过指定id获取WechatUserListDto信息
        /// </summary>
        Task<WechatUserListDto> GetById(long id);


        /// <summary>
        /// 返回实体的EditDto
        /// </summary>
        Task<GetWechatUserForEditOutput> GetForEdit(NullableIdDto<long> input);


        /// <summary>
        /// 添加或者修改WechatUser的公共方法
        /// </summary>
        Task CreateOrUpdate(CreateOrUpdateWechatUserInput input);


        /// <summary>
        /// 删除WechatUser信息的方法
        /// </summary>
        Task Delete(EntityDto<long> input);


        /// <summary>
        /// 批量删除WechatUser
        /// </summary>
        Task BatchDelete(List<long> input);

    }
}

