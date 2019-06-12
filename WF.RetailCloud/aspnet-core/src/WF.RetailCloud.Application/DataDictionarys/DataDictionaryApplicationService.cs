
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


using WF.RetailCloud.DataDictionarys;
using WF.RetailCloud.DataDictionarys.Dtos;
using WF.RetailCloud.DataDictionarys.DomainService;
using WF.RetailCloud.Dtos;
using Abp.Auditing;

namespace WF.RetailCloud.DataDictionarys
{
    /// <summary>
    /// DataDictionary应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize]
    public class DataDictionaryAppService : RetailCloudAppServiceBase, IDataDictionaryAppService
    {
        private readonly IRepository<DataDictionary, int> _entityRepository;

        private readonly IDataDictionaryManager _entityManager;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public DataDictionaryAppService(
        IRepository<DataDictionary, int> entityRepository
        , IDataDictionaryManager entityManager
        )
        {
            _entityRepository = entityRepository;
            _entityManager = entityManager;
        }


        /// <summary>
        /// 获取DataDictionary的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public async Task<PagedResultDto<DataDictionaryListDto>> GetPagedAsync(GetDataDictionarysInput input)
        {

            var query = _entityRepository.GetAll().WhereIf(input.Group.HasValue, a => a.Group == input.Group.Value)
                .WhereIf(!String.IsNullOrEmpty(input.Value), a => a.Value.Contains(input.Value));
            // TODO:根据传入的参数添加过滤条件


            var count = await query.CountAsync();

            var entityList = await query
                    .OrderBy(input.Sorting).AsNoTracking()
                    .PageBy(input)
                    .ToListAsync();

            // var entityListDtos = ObjectMapper.Map<List<DataDictionaryListDto>>(entityList);
            var entityListDtos = entityList.MapTo<List<DataDictionaryListDto>>();

            return new PagedResultDto<DataDictionaryListDto>(count, entityListDtos);
        }


        /// <summary>
        /// 通过指定id获取DataDictionaryListDto信息
        /// </summary>

        public async Task<DataDictionaryListDto> GetByIdAsync(EntityDto<int> input)
        {
            var entity = await _entityRepository.GetAsync(input.Id);

            return entity.MapTo<DataDictionaryListDto>();
        }

        /// <summary>
        /// 获取编辑 DataDictionary
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public async Task<GetDataDictionaryForEditOutput> GetForEditAsync(NullableIdDto<int> input)
        {
            var output = new GetDataDictionaryForEditOutput();
            DataDictionaryEditDto editDto;

            if (input.Id.HasValue)
            {
                var entity = await _entityRepository.GetAsync(input.Id.Value);

                editDto = entity.MapTo<DataDictionaryEditDto>();

                //dataDictionaryEditDto = ObjectMapper.Map<List<dataDictionaryEditDto>>(entity);
            }
            else
            {
                editDto = new DataDictionaryEditDto();
            }

            output.DataDictionary = editDto;
            return output;
        }


        /// <summary>
        /// 添加或者修改DataDictionary的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public async Task CreateOrUpdateAsync(CreateOrUpdateDataDictionaryInput input)
        {

            if (input.DataDictionary.Id.HasValue)
            {
                await UpdateAsync(input.DataDictionary);
            }
            else
            {
                await CreateAsync(input.DataDictionary);
            }
        }


        /// <summary>
        /// 新增DataDictionary
        /// </summary>

        protected virtual async Task<DataDictionaryEditDto> CreateAsync(DataDictionaryEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            // var entity = ObjectMapper.Map <DataDictionary>(input);
            input.CreationTime = DateTime.Now;
            var entity = input.MapTo<DataDictionary>();


            entity = await _entityRepository.InsertAsync(entity);
            return entity.MapTo<DataDictionaryEditDto>();
        }

        /// <summary>
        /// 编辑DataDictionary
        /// </summary>

        protected virtual async Task UpdateAsync(DataDictionaryEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _entityRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            // ObjectMapper.Map(input, entity);
            await _entityRepository.UpdateAsync(entity);
        }



        /// <summary>
        /// 删除DataDictionary信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public async Task DeleteAsync(EntityDto<int> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _entityRepository.DeleteAsync(input.Id);
        }



        /// <summary>
        /// 批量删除DataDictionary的方法
        /// </summary>

        public async Task BatchDeleteAsync(List<int> input)
        {
            // TODO:批量删除前的逻辑判断，是否允许删除
            await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        [AbpAllowAnonymous]
        [Audited]
        public async Task<List<DropDownDto>> GetDropDownDtosByGroupAsync(DataGroupEnum group)
        {
            var dropDownDtoList = await _entityRepository.GetAll().Where(aa => aa.Group == group)
               .OrderBy(aa => aa.CreationTime).AsNoTracking()
               .Select(aa => new DropDownDto
               {
                   Text = aa.Value,
                   Value = aa.Code
               }).ToListAsync();
            return dropDownDtoList;
        }

        /// <summary>
        /// 导出DataDictionary为excel表,等待开发。
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



