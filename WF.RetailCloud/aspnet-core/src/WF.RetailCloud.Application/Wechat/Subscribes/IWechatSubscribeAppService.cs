
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
using WF.RetailCloud.Wechat.Subscribes.Dtos;

namespace WF.RetailCloud.Wechat.Subscribes
{
    /// <summary>
    /// WechatSubscribe应用层服务的接口方法
    ///</summary>
    public interface IWechatSubscribeAppService : IApplicationService
    {
        /// <summary>
		/// 获取WechatSubscribe的分页列表信息
		///</summary>
        Task<PagedResultDto<WechatSubscribeListDto>> GetPaged(GetWechatSubscribesInput input);


		/// <summary>
		/// 通过指定id获取WechatSubscribeListDto信息
		/// </summary>
		Task<WechatSubscribeListDto> GetById(EntityDto input);


        /// <summary>
        /// 返回实体的EditDto
        /// </summary>
        Task<GetWechatSubscribeForEditOutput> GetForEdit(NullableIdDto<int> input);


        /// <summary>
        /// 添加或者修改WechatSubscribe的公共方法
        /// </summary>
        Task CreateOrUpdate(CreateOrUpdateWechatSubscribeInput input);


        /// <summary>
        /// 删除WechatSubscribe信息的方法
        /// </summary>
        Task Delete(EntityDto input);


        /// <summary>
        /// 批量删除WechatSubscribe
        /// </summary>
        Task BatchDelete(List<int> input);

        /// <summary>
        /// 获取第一条图文消息
        /// </summary>
        Task<WechatSubscribeListDto> GetWechatSubscribeInfo();

        /// <summary>
        /// 添加或者修改WechatSubscribe的公共方法
        /// </summary>
        Task CreateOrUpdateDto(WechatSubscribeEditDto input);

    }
}

