using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using WF.RetailCloud.Wechat.Messages.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Abp.Linq.Extensions;

namespace WF.RetailCloud.Wechat.Messages
{
    /// <summary>
    /// WechatMessage应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize]
    public class WechatMessageAppService : RetailCloudAppServiceBase, IWechatMessageAppService
    {
        private readonly IRepository<WechatMessage> _entityRepository;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public WechatMessageAppService(IRepository<WechatMessage> entityRepository)
        {
            _entityRepository = entityRepository;
        }


        /// <summary>
        /// 获取WechatMessage的分页列表信息
        ///</summary>

        public async Task<PagedResultDto<WechatMessageListDto>> GetPaged(GetWechatMessagesInput input)
        {

            var query = _entityRepository.GetAll()
                .WhereIf(!string.IsNullOrEmpty(input.MesText), m => m.KeyWord.Contains(input.MesText))
                .WhereIf(input.TriggerType.HasValue, m => m.TriggerType == input.TriggerType)
                .WhereIf(input.MsgType.HasValue, m => m.MsgType == input.MsgType);
            // TODO:根据传入的参数添加过滤条件


            var count = await query.CountAsync();

            var entityList = await query
                    .OrderBy(input.Sorting).AsNoTracking()
                    .PageBy(input)
                    .ToListAsync();

            // var entityListDtos = ObjectMapper.Map<List<WechatMessageListDto>>(entityList);
            var entityListDtos = entityList.MapTo<List<WechatMessageListDto>>();

            return new PagedResultDto<WechatMessageListDto>(count, entityListDtos);
        }


        /// <summary>
        /// 通过指定id获取WechatMessageListDto信息
        /// </summary>

        public async Task<WechatMessageListDto> GetById(EntityDto input)
        {
            var entity = await _entityRepository.GetAsync(input.Id);

            return entity.MapTo<WechatMessageListDto>();
        }

        /// <summary>
        /// 获取编辑 WechatMessage
        /// </summary>

        public async Task<GetWechatMessageForEditOutput> GetForEdit(NullableIdDto<int> input)
        {
            var output = new GetWechatMessageForEditOutput();
            WechatMessageEditDto editDto;

            if (input.Id.HasValue)
            {
                var entity = await _entityRepository.GetAsync(input.Id.Value);

                editDto = entity.MapTo<WechatMessageEditDto>();

                //wechatMessageEditDto = ObjectMapper.Map<List<wechatMessageEditDto>>(entity);
            }
            else
            {
                editDto = new WechatMessageEditDto();
            }

            output.WechatMessage = editDto;
            return output;
        }


        /// <summary>
        /// 添加或者修改WechatMessage的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public async Task CreateOrUpdate(CreateOrUpdateWechatMessageInput input)
        {

            if (input.WechatMessage.Id.HasValue)
            {
                await Update(input.WechatMessage);
            }
            else
            {
                await Create(input.WechatMessage);
            }
        }


        /// <summary>
        /// 新增WechatMessage
        /// </summary>

        protected virtual async Task<WechatMessageEditDto> Create(WechatMessageEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            // var entity = ObjectMapper.Map <WechatMessage>(input);
            var entity = input.MapTo<WechatMessage>();


            entity = await _entityRepository.InsertAsync(entity);
            return entity.MapTo<WechatMessageEditDto>();
        }

        /// <summary>
        /// 编辑WechatMessage
        /// </summary>

        protected virtual async Task Update(WechatMessageEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _entityRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            // ObjectMapper.Map(input, entity);
            await _entityRepository.UpdateAsync(entity);
        }



        /// <summary>
        /// 删除WechatMessage信息的方法
        /// </summary>

        public async Task Delete(EntityDto input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _entityRepository.DeleteAsync(input.Id);
        }



        /// <summary>
        /// 批量删除WechatMessage的方法
        /// </summary>

        public async Task BatchDelete(List<int> input)
        {
            // TODO:批量删除前的逻辑判断，是否允许删除
            await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        /// <summary>
        /// 添加或者修改WechatMessage的公共方法
        /// </summary>
        public async Task CreateOrUpdateDto(WechatMessageEditDto input)
        {
            if (input.Id.HasValue)
            {
                await Update(input);
            }
            else
            {
                await Create(input);
            }
        }

    }
}

