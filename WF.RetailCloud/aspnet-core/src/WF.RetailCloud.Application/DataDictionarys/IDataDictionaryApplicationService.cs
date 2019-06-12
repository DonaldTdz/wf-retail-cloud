
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


using WF.RetailCloud.DataDictionarys.Dtos;
using WF.RetailCloud.DataDictionarys;
using WF.RetailCloud.Dtos;

namespace WF.RetailCloud.DataDictionarys
{
    /// <summary>
    /// DataDictionary应用层服务的接口方法
    ///</summary>
    public interface IDataDictionaryAppService : IApplicationService
    {
        /// <summary>
		/// 获取DataDictionary的分页列表信息
		///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<DataDictionaryListDto>> GetPagedAsync(GetDataDictionarysInput input);

        /// <summary>
        /// 根据group获取字典下拉框
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        Task<List<DropDownDto>> GetDropDownDtosByGroupAsync(DataGroupEnum group);

        /// <summary>
        /// 通过指定id获取DataDictionaryListDto信息
        /// </summary>
        Task<DataDictionaryListDto> GetByIdAsync(EntityDto<int> input);


        /// <summary>
        /// 返回实体的EditDto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetDataDictionaryForEditOutput> GetForEditAsync(NullableIdDto<int> input);


        /// <summary>
        /// 添加或者修改DataDictionary的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdateAsync(CreateOrUpdateDataDictionaryInput input);


        /// <summary>
        /// 删除DataDictionary信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeleteAsync(EntityDto<int> input);


        /// <summary>
        /// 批量删除DataDictionary
        /// </summary>
        Task BatchDeleteAsync(List<int> input);


		/// <summary>
        /// 导出DataDictionary为excel表
        /// </summary>
        /// <returns></returns>
		//Task<FileDto> GetToExcel();

    }
}

