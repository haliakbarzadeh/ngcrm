using Goldiran.Framework.Domain.Contracts;
using NgCrm.BasicInfoService.Domain.Organizations.ReadModels;

namespace NgCrm.BasicInfoService.Domain.Organizations.Contracts
{
    public interface IOrganizationQueryRepository : IQueryRepository<OrganizationReadModel>
    {
        Task<IEnumerable<OrganizationReadModel>> GetAllByParentIdAsync(long organizationId, CancellationToken cancellationToken);
    }
}
