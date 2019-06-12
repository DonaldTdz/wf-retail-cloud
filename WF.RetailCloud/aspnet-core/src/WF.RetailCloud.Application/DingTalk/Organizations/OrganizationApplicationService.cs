
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


using WF.RetailCloud.DingTalk.Organizations;
using WF.RetailCloud.DingTalk.Organizations.Dtos;
using WF.RetailCloud.DingTalk.Organizations.DomainService;
using Senparc.CO2NET.HttpUtility;
using WF.RetailCloud.DingTalk.Employees.Dtos;
using WF.RetailCloud.DingTalk.Employees;
using WF.RetailCloud.Dtos;

namespace WF.RetailCloud.DingTalk.Organizations
{
    /// <summary>
    /// Organization应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize]
    public class OrganizationAppService : RetailCloudAppServiceBase, IOrganizationAppService
    {
        private readonly IRepository<Organization, long> _entityRepository;

        private readonly IOrganizationManager _entityManager;
        private readonly IRepository<Employee, string> _employeeRepository;
        private readonly IDingTalkManager _dingTalkManager;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public OrganizationAppService(
        IRepository<Organization, long> entityRepository,
        IDingTalkManager dingTalkManager
                , IRepository<Employee, string> employeeRepository
        , IOrganizationManager entityManager
        )
        {
            _entityRepository = entityRepository;
            _entityManager = entityManager;
            _employeeRepository = employeeRepository;
            _dingTalkManager = dingTalkManager;
        }


        /// <summary>
        /// 获取Organization的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public async Task<PagedResultDto<OrganizationListDto>> GetPagedAsync(GetOrganizationsInput input)
        {

            var query = _entityRepository.GetAll();
            // TODO:根据传入的参数添加过滤条件


            var count = await query.CountAsync();

            var entityList = await query
                    .OrderBy(input.Sorting).AsNoTracking()
                    .PageBy(input)
                    .ToListAsync();

            // var entityListDtos = ObjectMapper.Map<List<OrganizationListDto>>(entityList);
            var entityListDtos = entityList.MapTo<List<OrganizationListDto>>();

            return new PagedResultDto<OrganizationListDto>(count, entityListDtos);
        }


        /// <summary>
        /// 通过指定id获取OrganizationListDto信息
        /// </summary>

        public async Task<OrganizationListDto> GetByIdAsync(EntityDto<long> input)
        {
            var entity = await _entityRepository.GetAsync(input.Id);

            return entity.MapTo<OrganizationListDto>();
        }

        /// <summary>
        /// 获取编辑 Organization
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public async Task<GetOrganizationForEditOutput> GetForEditAsync(NullableIdDto<long> input)
        {
            var output = new GetOrganizationForEditOutput();
            OrganizationEditDto editDto;

            if (input.Id.HasValue)
            {
                var entity = await _entityRepository.GetAsync(input.Id.Value);

                editDto = entity.MapTo<OrganizationEditDto>();

                //organizationEditDto = ObjectMapper.Map<List<organizationEditDto>>(entity);
            }
            else
            {
                editDto = new OrganizationEditDto();
            }

            output.Organization = editDto;
            return output;
        }


        /// <summary>
        /// 添加或者修改Organization的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public async Task CreateOrUpdateAsync(CreateOrUpdateOrganizationInput input)
        {

            if (input.Organization.Id.HasValue)
            {
                await UpdateAsync(input.Organization);
            }
            else
            {
                await CreateAsync(input.Organization);
            }
        }


        /// <summary>
        /// 新增Organization
        /// </summary>

        protected virtual async Task<OrganizationEditDto> CreateAsync(OrganizationEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            // var entity = ObjectMapper.Map <Organization>(input);
            var entity = input.MapTo<Organization>();


            entity = await _entityRepository.InsertAsync(entity);
            return entity.MapTo<OrganizationEditDto>();
        }

        /// <summary>
        /// 编辑Organization
        /// </summary>

        protected virtual async Task UpdateAsync(OrganizationEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _entityRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            // ObjectMapper.Map(input, entity);
            await _entityRepository.UpdateAsync(entity);
        }



        /// <summary>
        /// 删除Organization信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public async Task DeleteAsync(EntityDto<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _entityRepository.DeleteAsync(input.Id);
        }



        /// <summary>
        /// 批量删除Organization的方法
        /// </summary>

        public async Task BatchDeleteAsync(List<long> input)
        {
            // TODO:批量删除前的逻辑判断，是否允许删除
            await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        public async Task<APIResultDto> SynchronousOrganizationAsync()
        {
            string accessToken = await _dingTalkManager.GetAccessTokenByAppAsync(DingDingAppEnum.智能办公); //GetAccessToken();
            var depts = Get.GetJson<DingDepartmentDto>(string.Format("https://oapi.dingtalk.com/department/list?access_token={0}", accessToken));
            var entityByDD = depts.department.Select(o => new OrganizationListDto()
            {
                Id = o.id,
                DepartmentName = o.name,
                ParentId = o.parentid,
                CreationTime = DateTime.Now
            }).ToList();

            var originEntity = await _entityRepository.GetAll().ToListAsync();
            foreach (var item in entityByDD)
            {
                var o = originEntity.Where(r => r.Id == item.Id).FirstOrDefault();
                if (o != null)
                {
                    o.DepartmentName = item.DepartmentName;
                    o.ParentId = item.ParentId;
                    o.CreationTime = DateTime.Now;
                    if (o.Id != 1)
                    {
                        await SynchronousEmployeeAsync(o.Id, accessToken);
                    }
                }
                else
                {
                    var organization = new OrganizationListDto();
                    organization.Id = item.Id;
                    organization.DepartmentName = item.DepartmentName;
                    organization.ParentId = item.ParentId;
                    organization.CreationTime = DateTime.Now;
                    await CreateSyncOrganizationAsync(organization);
                    if (organization.Id != 1)
                    {
                        await SynchronousEmployeeAsync(organization.Id, accessToken);
                    }
                }
            }
            await CurrentUnitOfWork.SaveChangesAsync();
            return new APIResultDto() { Code = 0, Msg = "同步组织架构成功" };
        }

        /// <summary>
        /// 同步内部员工
        /// </summary>
        private async Task<APIResultDto> SynchronousEmployeeAsync(long departId, string accessToken)
        {
            try
            {
                /*IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/user/list");
                OapiUserListRequest request = new OapiUserListRequest();
                request.DepartmentId = departId;
                request.SetHttpMethod("GET");
                OapiUserListResponse response = client.Execute(request, accessToken);*/
                var url = string.Format("https://oapi.dingtalk.com/user/list?access_token={0}&department_id={1}", accessToken, departId);
                var user = Get.GetJson<DingUserListDto>(url);
                var entityByDD = user.userlist.Select(e => new EmployeeListDto()
                {
                    Id = e.userid,
                    Unionid = e.unionid,
                    Name = e.name,
                    Mobile = e.mobile,
                    Position = e.position,
                    Department = e.departmentStr.Replace("[","").Replace("]",""),
                    Email = e.email,
                    IsLeaderInDepts = "key:" + departId + "value:" + e.isLeader,
                    HiredDate = NewDate(e.hiredDate),
                    JobNumber = e.jobnumber,
                    Avatar = e.avatar,
                    Active = e.active
                }).ToList();
                var originEntity = await _employeeRepository.GetAll().ToListAsync();
                foreach (var item in entityByDD)
                {
                    var e = originEntity.Where(r => r.Id == item.Id).FirstOrDefault();
                    if (e != null)
                    {
                        e.Unionid = item.Unionid;
                        e.IsLeaderInDepts = item.IsLeaderInDepts;
                        e.Name = item.Name;
                        e.Mobile = item.Mobile;
                        e.Position = item.Position;
                        e.Department = item.Department;
                        e.JobNumber = item.JobNumber;
                        e.Email = item.Email;
                        e.HiredDate = item.HiredDate;
                        e.Avatar = item.Avatar;
                        e.Active = item.Active;
                    }
                    else
                    {
                        var employee = new EmployeeListDto();
                        employee.Id = item.Id;
                        employee.Unionid = item.Unionid;
                        employee.IsLeaderInDepts = item.IsLeaderInDepts;
                        employee.JobNumber = item.JobNumber;
                        employee.Name = item.Name;
                        employee.Mobile = item.Mobile;
                        employee.Position = item.Position;
                        employee.Department = item.Department;
                        employee.Email = item.Email;
                        employee.HiredDate = item.HiredDate;
                        employee.Avatar = item.Avatar;
                        employee.Active = item.Active;
                        employee.CreationTime = DateTime.Now;
                        await CreateSyncEmployeeAsync(employee);
                    }
                }
                await CurrentUnitOfWork.SaveChangesAsync();
                return new APIResultDto() { Code = 0, Msg = "同步内部员工成功" };
            }
            catch (Exception ex)
            {
                Logger.ErrorFormat("SynchronousEmployeeAsync errormsg{0} Exception{1}", ex.Message, ex);
                return new APIResultDto() { Code = 901, Msg = "同步内部员工失败" };
            }
        }

        /// <summary>
        /// 把时间戳转换为datetime
        /// </summary>
        /// <param name="timestamp"></param>
        /// <returns></returns>
        public DateTime? NewDate(string timestamp)
        {
            long hiredDate;
            if (!String.IsNullOrEmpty(timestamp) && long.TryParse(timestamp+"0000", out hiredDate))
            {
                DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
                TimeSpan toNow = new TimeSpan(hiredDate);
                var bb=dtStart.Add(toNow);
                return bb;
            }
            else
            {
                return null;
            }
        }

        ///// <summary>
        ///// 插入组织架构
        ///// </summary>
        ///// <param name="input"></param>
        ///// <returns></returns>
        private async Task<Organization> CreateSyncOrganizationAsync(OrganizationListDto input)
        {
            var entity = ObjectMapper.Map<Organization>(input);
            entity = await _entityRepository.InsertAsync(entity);
            return entity.MapTo<Organization>();
        }

        private async Task<Employee> CreateSyncEmployeeAsync(EmployeeListDto input)
        {
            var entity = ObjectMapper.Map<Employee>(input);
            entity = await _employeeRepository.InsertAsync(entity);
            return entity.MapTo<Employee>();
        }

        public async Task<List<OrganizationNzTreeNode>> GetTreesAsync()
        {
            int? count = 0;
            var organizationList = await (from o in _entityRepository.GetAll()
                                          select new OrganizationListDto()
                                          {
                                              Id = o.Id,
                                              DepartmentName = o.DepartmentName,
                                              //OrgDeptName = o.DepartmentName,
                                              ParentId = o.ParentId
                                          }).ToListAsync();
            foreach (var item in organizationList)
            {
                if (item.Id == 1)
                    count = await _employeeRepository.GetAll().CountAsync();
                else
                    count = await _employeeRepository.GetAll().Where(v => v.Department.Contains(item.Id.ToString())).CountAsync();
                item.Id = item.Id;
                item.ParentId = item.ParentId;
                item.DepartmentName = item.DepartmentName + $"({count}人)";
            }
            return GetTrees(0, organizationList);
        }

        private List<OrganizationNzTreeNode> GetTrees(long? id, List<OrganizationListDto> organizationList)
        {
            List<OrganizationNzTreeNode> treeNodeList = organizationList.Where(o => o.ParentId == id).Select(t => new OrganizationNzTreeNode()
            {
                key = t.Id.ToString(),
                title = t.DepartmentName,
                //deptName = t.OrgDeptName,
                children = GetTrees(t.Id, organizationList)
            }).ToList();
            return treeNodeList;
        }

        /// <summary>
        /// 导出Organization为excel表,等待开发。
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



