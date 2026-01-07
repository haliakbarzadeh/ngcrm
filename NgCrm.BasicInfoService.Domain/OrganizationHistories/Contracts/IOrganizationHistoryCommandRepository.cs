using Goldiran.Framework.Domain.Contracts;
using NgCrm.BasicInfoService.Domain.OrganizationHistories.Entities;
using NgCrm.BasicInfoService.Domain.OrganizationHistories.ReadModels;

namespace NgCrm.BasicInfoService.Domain.OrganizationHistories.Contracts
{
    public interface IOrganizationHistoryCommandRepository : ICommandRepository<OrganizationHistory>
    {
        Task GenerateOrganizationHistory(CancellationToken cancellationToken);
    }
}
