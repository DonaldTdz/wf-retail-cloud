
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


using WF.RetailCloud.DingTalk.DingTalkConfigs;
using WF.RetailCloud.DingTalk.DingTalkConfigs.Dtos;
using WF.RetailCloud.DingTalk.DingTalkConfigs.DomainService;



namespace WF.RetailCloud.DingTalk.DingTalkConfigs
{
    /// <summary>
    /// DingTalkConfig应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize]
    public class DingTalkConfigAppService : RetailCloudAppServiceBase, IDingTalkConfigAppService
    {
        private readonly IRepository<DingTalkConfig> _entityRepository;

        private readonly IDingTalkConfigManager _entityManager;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public DingTalkConfigAppService(
        IRepository<DingTalkConfig> entityRepository
        , IDingTalkConfigManager entityManager
        )
        {
            _entityRepository = entityRepository;
            _entityManager = entityManager;
        }


        /// <summary>
        /// 获取DingTalkConfig的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public async Task<PagedResultDto<DingTalkConfigListDto>> GetPagedAsync(GetDingTalkConfigsInput input)
        {

            var query = _entityRepository.GetAll();
            // TODO:根据传入的参数添加过滤条件


            var count = await query.CountAsync();


            var entityList = await query
                    .OrderBy(v => v.Seq).AsNoTracking()
                    .PageBy(input)
                    .ToListAsync();

            // var entityListDtos = ObjectMapper.Map<List<DingTalkConfigListDto>>(entityList);
            var entityListDtos = entityList.MapTo<List<DingTalkConfigListDto>>();
            return new PagedResultDto<DingTalkConfigListDto>(count, entityListDtos);
        }


        /// <summary>
        /// 通过指定id获取DingTalkConfigListDto信息
        /// </summary>

        public async Task<DingTalkConfigListDto> GetByIdAsync(EntityDto<int> input)
        {
            var entity = await _entityRepository.GetAsync(input.Id);

            return entity.MapTo<DingTalkConfigListDto>();
        }

        /// <summary>
        /// 获取编辑 DingTalkConfig
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public async Task<GetDingTalkConfigForEditOutput> GetForEditAsync(NullableIdDto<int> input)
        {
            var output = new GetDingTalkConfigForEditOutput();
            DingTalkConfigEditDto editDto;

            if (input.Id.HasValue)
            {
                var entity = await _entityRepository.GetAsync(input.Id.Value);

                editDto = entity.MapTo<DingTalkConfigEditDto>();

                //dingTalkConfigEditDto = ObjectMapper.Map<List<dingTalkConfigEditDto>>(entity);
            }
            else
            {
                editDto = new DingTalkConfigEditDto();
            }

            output.DingTalkConfig = editDto;
            return output;
        }


        /// <summary>
        /// 添加或者修改DingTalkConfig的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public async Task CreateOrUpdateAsync(DingTalkConfigEditDto input)
        {
            if (input.Id.HasValue)
            {
                await UpdateAsync(input);
            }
            else
            {
                input.CreationTime = DateTime.Now;
                await CreateAsync(input);
            }
        }


        /// <summary>
        /// 新增DingTalkConfig
        /// </summary>

        protected virtual async Task<DingTalkConfigEditDto> CreateAsync(DingTalkConfigEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增


            // var entity = ObjectMapper.Map <DingTalkConfig>(input);
            var entity = input.MapTo<DingTalkConfig>();
            entity.CreationTime = DateTime.Now;
            entity = await _entityRepository.InsertAsync(entity);
            return entity.MapTo<DingTalkConfigEditDto>();
        }

        /// <summary>
        /// 编辑DingTalkConfig
        /// </summary>

        protected virtual async Task UpdateAsync(DingTalkConfigEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _entityRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            // ObjectMapper.Map(input, entity);
            await _entityRepository.UpdateAsync(entity);
        }



        /// <summary>
        /// 删除DingTalkConfig信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public async Task DeleteAsync(EntityDto<int> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _entityRepository.DeleteAsync(input.Id);
        }



        /// <summary>
        /// 批量删除DingTalkConfig的方法
        /// </summary>

        public async Task BatchDeleteAsync(List<int> input)
        {
            // TODO:批量删除前的逻辑判断，是否允许删除
            await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        public async Task<PagedResultDto<DingTalkConfigListDto>> GetPagedByTypeAsync(GetDingTalkConfigsInput input, int type=1)
        {
            var DingDingTypeBool = Enum.IsDefined(typeof(DingDingTypeEnum), type);
            DingDingTypeEnum dingDingTypeEnum = DingDingTypeEnum.公共配置;
            if (DingDingTypeBool == true)
                dingDingTypeEnum = (DingDingTypeEnum)type;
            var query = _entityRepository.GetAll().Where(aa => aa.Type == dingDingTypeEnum);
            // TODO:根据传入的参数添加过滤条件

            var count = await query.CountAsync();

            var entityList = await query
                    .OrderBy(a => a.Seq).AsNoTracking()
                    .PageBy(input)
                    .ToListAsync();

            // var systemdataListDtos = ObjectMapper.Map<List <SystemDataListDto>>(systemdatas);
            var entityListDtos = entityList.MapTo<List<DingTalkConfigListDto>>();

            return new PagedResultDto<DingTalkConfigListDto>(count, entityListDtos);
        }

        /// <summary>
        /// 导出DingTalkConfig为excel表,等待开发。
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



