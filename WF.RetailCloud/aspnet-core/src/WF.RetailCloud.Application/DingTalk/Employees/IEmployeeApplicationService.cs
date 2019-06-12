
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


using WF.RetailCloud.DingTalk.Employees.Dtos;
using WF.RetailCloud.DingTalk.Employees;
using WF.RetailCloud.Dtos;

namespace WF.RetailCloud.DingTalk.Employees
{
    /// <summary>
    /// Employee应用层服务的接口方法
    ///</summary>
    public interface IEmployeeAppService : IApplicationService
    {
        /// <summary>
		/// 获取Employee的分页列表信息
		///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<EmployeeListDto>> GetPagedAsync(GetEmployeesInput input);


		/// <summary>
		/// 通过指定id获取EmployeeListDto信息
		/// </summary>
		Task<EmployeeListDto> GetByIdAsync(string id);

        /// <summary>
        /// 获取人员下拉列表
        /// </summary>
        /// <returns></returns>
        Task<List<DropDownDto>> GetDropDownDtosAsync();


        ///// <summary>
        ///// 返回实体的EditDto
        ///// </summary>
        ///// <param name="input"></param>
        ///// <returns></returns>
        //Task<GetEmployeeForEditOutput> GetForEditAsync(NullableIdDto<string> input);


        /// <summary>
        /// 添加或者修改Employee的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdateAsync(CreateOrUpdateEmployeeInput input);


        /// <summary>
        /// 删除Employee信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeleteAsync(EntityDto<string> input);


        /// <summary>
        /// 批量删除Employee
        /// </summary>
        Task BatchDeleteAsync(List<string> input);


        Task<PagedResultDto<EmployeeListDto>> GetEmployeeListByIdAsync(GetEmployeesInput input);

        /// <summary>
        /// 导出Employee为excel表
        /// </summary>
        /// <returns></returns>
        //Task<FileDto> GetToExcel();

        //获取钉钉用户信息
        Task<DingDingUserDto> GetDingDingUserByCodeAsync(string code);

    }
}

