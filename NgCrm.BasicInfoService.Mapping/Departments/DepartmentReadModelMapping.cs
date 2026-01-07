using Goldiran.Framework.Mapping.Mapster;
using NgCrm.BasicInfoService.Domain.Departments.Dtos;
using NgCrm.BasicInfoService.Domain.Departments.ReadModels;

namespace NgCrm.BasicInfoService.Mapping.Departments
{
    public class DepartmentReadModelMapping : MapProfile<DepartmentReadModel, DepartmentDto>
    {
        public DepartmentReadModelMapping()
        {
        }
    }
}