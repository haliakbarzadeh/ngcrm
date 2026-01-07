using Goldiran.Framework.Domain.Contracts;
using NgCrm.BasicInfoService.Domain.Permissions.ReadModels;

namespace NgCrm.BasicInfoService.Domain.Permissions.Contracts
{
    public interface IPermissionQueryRepository : IQueryRepository<PermissionReadModel>
    {
        Task<IEnumerable<PermissionReadModel>> GetByIdsAsync(IEnumerable<long> Ids, CancellationToken cancellationToken);

    }
}
