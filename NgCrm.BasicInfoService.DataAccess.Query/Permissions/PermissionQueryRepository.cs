using Goldiran.Framework.EFCore.Repositories;
using Microsoft.EntityFrameworkCore;
using NgCrm.BasicInfoService.Domain.Permissions.Contracts;
using NgCrm.BasicInfoService.Domain.Permissions.ReadModels;

namespace NgCrm.BasicInfoService.DataAccess.Query.Permissions
{
    public class PermissionQueryRepository : QueryRepository<PermissionReadModel, BasicInfoQueryContext>, IPermissionQueryRepository
    {
        public PermissionQueryRepository(BasicInfoQueryContext dbContext)
            : base(dbContext)
        {

        }

        public async Task<IEnumerable<PermissionReadModel>> GetByIdsAsync(IEnumerable<long> ids, CancellationToken cancellationToken)
        {
            return await this.EntitySet.Where(e => ids.Contains(e.Id)).ToListAsync(cancellationToken);
        }
    }
}
