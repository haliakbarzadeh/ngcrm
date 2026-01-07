using Goldiran.Framework.EFCore.Repositories;
using Microsoft.EntityFrameworkCore;
using NgCrm.BasicInfoService.Domain.Departments.Contracts;
using NgCrm.BasicInfoService.Domain.Departments.ReadModels;

namespace NgCrm.BasicInfoService.DataAccess.Query.Departments
{
    public class DepartmentQueryRepository : QueryRepository<DepartmentReadModel, BasicInfoQueryContext>, IDepartmentQueryRepository
    {
        public DepartmentQueryRepository(BasicInfoQueryContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<DepartmentReadModel>> GetAllByParentIdAsync(long departmentId, CancellationToken cancellationToken)
        {
            var list = await this.EntitySet.Where(e => e.ParentId == departmentId).ToListAsync(cancellationToken);
            return list;
        }

        public async Task<IEnumerable<DepartmentReadModel>> GetActiveAsync(CancellationToken cancellationToken)
        {
            var list = await this.EntitySet.Where(e => e.IsActive).ToListAsync(cancellationToken);
            return list;
        }
    }
}