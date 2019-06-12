using Abp.Application.Services;
using Abp.Application.Services.Dto;
using WF.RetailCloud.Wechat.Messages.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WF.RetailCloud.Wechat.Messages
{
    public interface IWechatMessageAppService : IApplicationService
    {
        /// <summary>
        /// 获取WechatMessage的分页列表信息
        ///</summary>
        Task<PagedResultDto<WechatMessageListDto>> GetPaged(GetWechatMessagesInput input);


        /// <summary>
        /// 通过指定id获取WechatMessageListDto信息
        /// </summary>
        Task<WechatMessageListDto> GetById(EntityDto input);


        /// <summary>
        /// 返回实体的EditDto
        /// </summary>
        Task<GetWechatMessageForEditOutput> GetForEdit(NullableIdDto<int> input);


        /// <summary>
        /// 添加或者修改WechatMessage的公共方法
        /// </summary>
        Task CreateOrUpdate(CreateOrUpdateWechatMessageInput input);


        /// <summary>
        /// 删除WechatMessage信息的方法
        /// </summary>
        Task Delete(EntityDto input);


        /// <summary>
        /// 批量删除WechatMessage
        /// </summary>
        Task BatchDelete(List<int> input);

        /// <summary>
        /// 添加或者修改WechatMessage的公共方法 
        Task CreateOrUpdateDto(WechatMessageEditDto input);
    }
}

