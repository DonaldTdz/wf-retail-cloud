
using AutoMapper;
using WF.RetailCloud.DingTalk.Employees;
using WF.RetailCloud.DingTalk.Employees.Dtos;

namespace WF.RetailCloud.DingTalk.Employees.Mapper
{

	/// <summary>
    /// 配置Employee的AutoMapper
    /// </summary>
	internal static class EmployeeMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <Employee,EmployeeListDto>();
            configuration.CreateMap <EmployeeListDto,Employee>();

            configuration.CreateMap <EmployeeEditDto,Employee>();
            configuration.CreateMap <Employee,EmployeeEditDto>();

        }
	}
}

