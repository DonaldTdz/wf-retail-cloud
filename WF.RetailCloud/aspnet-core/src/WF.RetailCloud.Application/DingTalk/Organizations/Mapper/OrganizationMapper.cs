
using AutoMapper;
using WF.RetailCloud.DingTalk.Organizations;
using WF.RetailCloud.DingTalk.Organizations.Dtos;

namespace WF.RetailCloud.DingTalk.Organizations.Mapper
{

	/// <summary>
    /// 配置Organization的AutoMapper
    /// </summary>
	internal static class OrganizationMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <Organization,OrganizationListDto>();
            configuration.CreateMap <OrganizationListDto,Organization>();

            configuration.CreateMap <OrganizationEditDto,Organization>();
            configuration.CreateMap <Organization,OrganizationEditDto>();

        }
	}
}

