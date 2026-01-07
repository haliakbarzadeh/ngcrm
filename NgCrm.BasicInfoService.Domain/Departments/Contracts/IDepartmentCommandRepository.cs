using Goldiran.Framework.Domain.Contracts;
using NgCrm.BasicInfoService.Domain.Departments.Entities;

namespace NgCrm.BasicInfoService.Domain.Departments.Contracts
{
    public interface IDepartmentCommandRepository : ICommandRepository<Department>
    {
    }
}