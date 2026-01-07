using Goldiran.Framework.Domain.Contracts;
using NgCrm.BasicInfoService.Domain.PersonAccessGroups.Entities;

namespace NgCrm.BasicInfoService.Domain.PersonAccessGroups.Contracts
{
    public interface IPersonAccessGroupCommandRepository : ICommandRepository<PersonAccessGroup>
    {
        Task<IEnumerable<PersonAccessGroup>> GetByPersonIdAsync(long personId, CancellationToken cancellationToken);
        Task<IEnumerable<PersonAccessGroup>> GetByAccessGroupIdAsync(long accessGroupId, CancellationToken cancellationToken);
    }
}