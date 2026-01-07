using Goldiran.Framework.Domain.Contracts;
using NgCrm.BasicInfoService.Domain.OrganizationHistories.ReadModels;

namespace NgCrm.BasicInfoService.Domain.OrganizationHistories.Contracts
{
    public interface IOrganizationHistoryQueryRepository : IQueryRepository<OrganizationHistoryReadModel>
    {
        Task<OrganizationHistoryReadModel?> GetByDateAsync(DateTime fromDate, CancellationToken cancellationToken);
    }
}
