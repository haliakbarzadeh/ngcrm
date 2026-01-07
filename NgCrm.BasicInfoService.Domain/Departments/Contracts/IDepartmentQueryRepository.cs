using Goldiran.Framework.Domain.Contracts;
using NgCrm.BasicInfoService.Domain.Departments.ReadModels;

namespace NgCrm.BasicInfoService.Domain.Departments.Contracts
{
    public interface IDepartmentQueryRepository : IQueryRepository<DepartmentReadModel>
    {
        Task<IEnumerable<DepartmentReadModel>> GetAllByParentIdAsync(long departmentId, CancellationToken cancellationToken);
        Task<IEnumerable<DepartmentReadModel>> GetActiveAsync(CancellationToken cancellationToken);
    }
}