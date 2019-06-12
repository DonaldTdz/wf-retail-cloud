
using AutoMapper;
using WF.RetailCloud.DingTalk.DingTalkConfigs;
using WF.RetailCloud.DingTalk.DingTalkConfigs.Dtos;

namespace WF.RetailCloud.DingTalk.DingTalkConfigs.Mapper
{

	/// <summary>
    /// 配置DingTalkConfig的AutoMapper
    /// </summary>
	internal static class DingTalkConfigMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <DingTalkConfig,DingTalkConfigListDto>();
            configuration.CreateMap <DingTalkConfigListDto,DingTalkConfig>();

            configuration.CreateMap <DingTalkConfigEditDto,DingTalkConfig>();
            configuration.CreateMap <DingTalkConfig,DingTalkConfigEditDto>();

        }
	}
}

