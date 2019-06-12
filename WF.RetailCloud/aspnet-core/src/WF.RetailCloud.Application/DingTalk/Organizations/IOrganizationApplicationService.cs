
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


using WF.RetailCloud.DingTalk.Organizations.Dtos;
using WF.RetailCloud.DingTalk.Organizations;
using WF.RetailCloud.Dtos;

namespace WF.RetailCloud.DingTalk.Organizations
{
    /// <summary>
    /// Organization应用层服务的接口方法
    ///</summary>
    public interface IOrganizationAppService : IApplicationService
    {
        /// <summary>
		/// 获取Organization的分页列表信息
		///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<OrganizationListDto>> GetPagedAsync(GetOrganizationsInput input);


        /// <summary>
        /// 通过指定id获取OrganizationListDto信息
        /// </summary>
        Task<OrganizationListDto> GetByIdAsync(EntityDto<long> input);


        /// <summary>
        /// 返回实体的EditDto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetOrganizationForEditOutput> GetForEditAsync(NullableIdDto<long> input);


        /// <summary>
        /// 添加或者修改Organization的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdateAsync(CreateOrUpdateOrganizationInput input);


        /// <summary>
        /// 删除Organization信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeleteAsync(EntityDto<long> input);


        /// <summary>
        /// 批量删除Organization
        /// </summary>
        Task BatchDeleteAsync(List<long> input);


        Task<APIResultDto> SynchronousOrganizationAsync();

        Task<List<OrganizationNzTreeNode>> GetTreesAsync();


        /// <summary>
        /// 导出Organization为excel表
        /// </summary>
        /// <returns></returns>
        //Task<FileDto> GetToExcel();

    }
}

