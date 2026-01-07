using Goldiran.Framework.Mapping.Mapster;
using NgCrm.BasicInfoService.Domain.Departments.Dtos;
using NgCrm.BasicInfoService.Domain.Departments.Entities;

namespace NgCrm.BasicInfoService.Mapping.Departments
{
    public class DepartmentMapping : MapProfile<Department, DepartmentDto>
    {
        public DepartmentMapping()
        {
            ForMember(x => x.Id, x => x.Id);
        }
    }
}