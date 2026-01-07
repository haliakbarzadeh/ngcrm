using Goldiran.Framework.EFCore.Repositories;
using NgCrm.BasicInfoService.Domain.Departments.Contracts;
using NgCrm.BasicInfoService.Domain.Departments.Entities;

namespace NgCrm.BasicInfoService.DataAccess.Command.Departments
{
    public class DepartmentCommandRepository : CommandRepository<Department, BasicInfoCommandContext>, IDepartmentCommandRepository
    {
        public DepartmentCommandRepository(BasicInfoCommandContext dbContext) : base(dbContext)
        {
        }
    }
}