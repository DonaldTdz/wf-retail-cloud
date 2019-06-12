
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
using Abp.Extensions;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Application.Services.Dto;
using Abp.Linq.Extensions;


using WF.RetailCloud.DingTalk.Employees;
using WF.RetailCloud.DingTalk.Employees.Dtos;
using WF.RetailCloud.DingTalk.Employees.DomainService;
using WF.RetailCloud.Dtos;
using Abp.Auditing;

namespace WF.RetailCloud.DingTalk.Employees
{
    /// <summary>
    /// Employee应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize]
    public class EmployeeAppService : RetailCloudAppServiceBase, IEmployeeAppService
    {
        private readonly IRepository<Employee, string> _entityRepository;

        private readonly IEmployeeManager _entityManager;

        private readonly IDingTalkManager _dingTalkManager;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public EmployeeAppService(
        IRepository<Employee, string> entityRepository
        , IEmployeeManager entityManager
        , IDingTalkManager dingTalkManager
        )
        {
            _entityRepository = entityRepository;
            _entityManager = entityManager;
            _dingTalkManager = dingTalkManager;
        }


        /// <summary>
        /// 获取Employee的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public async Task<PagedResultDto<EmployeeListDto>> GetPagedAsync(GetEmployeesInput input)
        {

            var query = _entityRepository.GetAll();
            // TODO:根据传入的参数添加过滤条件


            var count = await query.CountAsync();

            var entityList = await query
                    .OrderBy(input.Sorting).AsNoTracking()
                    .PageBy(input)
                    .ToListAsync();

            // var entityListDtos = ObjectMapper.Map<List<EmployeeListDto>>(entityList);
            var entityListDtos = entityList.MapTo<List<EmployeeListDto>>();

            return new PagedResultDto<EmployeeListDto>(count, entityListDtos);
        }


        /// <summary>
        /// 通过指定id获取EmployeeListDto信息
        /// </summary>

        public async Task<EmployeeListDto> GetByIdAsync(string id)
        {
            var entity = await _entityRepository.GetAsync(id);

            return entity.MapTo<EmployeeListDto>();
        }

        //		/// <summary>
        //		/// 获取编辑 Employee
        //		/// </summary>
        //		/// <param name="input"></param>
        //		/// <returns></returns>

        //		public async Task<GetEmployeeForEditOutput> GetForEditAsync(NullableIdDto<string> input)
        //		{
        //			var output = new GetEmployeeForEditOutput();
        //EmployeeEditDto editDto;

        //			if (input.Id.HasValue)
        //			{
        //				var entity = await _entityRepository.GetAsync(input.Id.Value);

        //				editDto = entity.MapTo<EmployeeEditDto>();

        //				//employeeEditDto = ObjectMapper.Map<List<employeeEditDto>>(entity);
        //			}
        //			else
        //			{
        //				editDto = new EmployeeEditDto();
        //			}

        //			output.Employee = editDto;
        //			return output;
        //		}


        /// <summary>
        /// 添加或者修改Employee的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public async Task CreateOrUpdateAsync(CreateOrUpdateEmployeeInput input)
        {

            if (String.IsNullOrEmpty(input.Employee.Id))
            {
                await UpdateAsync(input.Employee);
            }
            else
            {
                await CreateAsync(input.Employee);
            }
        }


        /// <summary>
        /// 新增Employee
        /// </summary>

        protected virtual async Task<EmployeeEditDto> CreateAsync(EmployeeEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            // var entity = ObjectMapper.Map <Employee>(input);
            var entity = input.MapTo<Employee>();


            entity = await _entityRepository.InsertAsync(entity);
            return entity.MapTo<EmployeeEditDto>();
        }

        /// <summary>
        /// 编辑Employee
        /// </summary>

        protected virtual async Task UpdateAsync(EmployeeEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _entityRepository.GetAsync(input.Id);
            input.MapTo(entity);

            // ObjectMapper.Map(input, entity);
            await _entityRepository.UpdateAsync(entity);
        }



        /// <summary>
        /// 删除Employee信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public async Task DeleteAsync(EntityDto<string> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _entityRepository.DeleteAsync(input.Id);
        }



        /// <summary>
        /// 批量删除Employee的方法
        /// </summary>

        public async Task BatchDeleteAsync(List<string> input)
        {
            // TODO:批量删除前的逻辑判断，是否允许删除
            await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        public async Task<PagedResultDto<EmployeeListDto>> GetEmployeeListByIdAsync(GetEmployeesInput input)
        {
            var query = _entityRepository.GetAll()
              .WhereIf(!string.IsNullOrEmpty(input.Mobile), u => u.Mobile.Contains(input.Mobile))
        .WhereIf(!string.IsNullOrEmpty(input.Name), u => u.Name.Contains(input.Name))
            .WhereIf(!string.IsNullOrEmpty(input.DepartId) && input.DepartId != "1", u => u.Department.Contains(input.DepartId));
            var employeeCount = await query.CountAsync();

            var employees = await query
                    .OrderBy(v => v.Id).AsNoTracking()
                    .PageBy(input)
                    .ToListAsync();
            var employeeListDtos = employees.MapTo<List<EmployeeListDto>>();

            return new PagedResultDto<EmployeeListDto>(
                    employeeCount,
                    employeeListDtos
                );
        }

        public async Task<List<DropDownDto>> GetDropDownDtosAsync()
        {
            var DropDownDtoList = await _entityRepository.GetAll()
                .OrderBy(a => a.CreationTime).AsNoTracking()
                .Select(aa => new DropDownDto()
                {
                    Text = aa.Name,
                    Value = aa.Id
                }).ToListAsync();
            return DropDownDtoList;
        }

        [AbpAllowAnonymous]
        [Audited]
        public async Task<DingDingUserDto> GetDingDingUserByCodeAsync(string code)
        {
            var assessToken = await _dingTalkManager.GetAccessTokenByAppAsync(DingDingAppEnum.智能办公);
            var userId = _dingTalkManager.GetUserId(assessToken, code);
            //var userId = "165500493321719640";
            var query = await _entityRepository.GetAsync(userId);
            var dduser = query.MapTo<DingDingUserDto>();

            return dduser;
        }

        /// <summary>
        /// 导出Employee为excel表,等待开发。
        /// </summary>
        /// <returns></returns>
        //public async Task<FileDto> GetToExcel()
        //{
        //	var users = await UserManager.Users.ToListAsync();
        //	var userListDtos = ObjectMapper.Map<List<UserListDto>>(users);
        //	await FillRoleNames(userListDtos);
        //	return _userListExcelExporter.ExportToFile(userListDtos);
        //}

    }
}



