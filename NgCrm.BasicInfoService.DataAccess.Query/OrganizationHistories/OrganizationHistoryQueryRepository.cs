using Goldiran.Framework.EFCore.Repositories;
using Microsoft.EntityFrameworkCore;
using NgCrm.BasicInfoService.Domain.OrganizationHistories.Contracts;
using NgCrm.BasicInfoService.Domain.OrganizationHistories.ReadModels;

namespace NgCrm.BasicInfoService.DataAccess.Query.OrganizationHistories
{
    public class OrganizationHistoryQueryRepository : QueryRepository<OrganizationHistoryReadModel, BasicInfoQueryContext>, IOrganizationHistoryQueryRepository
    {
        public OrganizationHistoryQueryRepository(BasicInfoQueryContext dbContext) : base(dbContext)
        {

        }

        public async Task<OrganizationHistoryReadModel?> GetByDateAsync(DateTime fromDate, CancellationToken cancellationToken)
        {
            var result = await EntitySet.Where(e => e.FromDate > fromDate).OrderBy(e => e.FromDate).FirstOrDefaultAsync();
            return result;
        }
    }
}
