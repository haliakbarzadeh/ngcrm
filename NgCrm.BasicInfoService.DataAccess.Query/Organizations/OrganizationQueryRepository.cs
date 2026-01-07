using Goldiran.Framework.EFCore.Repositories;
using Microsoft.EntityFrameworkCore;
using NgCrm.BasicInfoService.Domain.Organizations.Contracts;
using NgCrm.BasicInfoService.Domain.Organizations.ReadModels;

namespace NgCrm.BasicInfoService.DataAccess.Query.Organizations
{
    public class OrganizationQueryRepository : QueryRepository<OrganizationReadModel, BasicInfoQueryContext>, IOrganizationQueryRepository
    {
        public OrganizationQueryRepository(BasicInfoQueryContext dbContext) : base(dbContext)
        {

        }


        public async Task<IEnumerable<OrganizationReadModel>> GetAllByParentIdAsync(long organizationId, CancellationToken cancellationToken)
        {
            var list = await EntitySet.Where(e => e.ParentId == organizationId).ToListAsync(cancellationToken);
            return list;
        }
    }
}
