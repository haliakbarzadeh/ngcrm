using Goldiran.Framework.Domain.Contracts;
using NgCrm.BasicInfoService.Domain.Persons.Entities;

namespace NgCrm.BasicInfoService.Domain.Persons.Contracts
{
    public interface IPersonCommandRepository : ICommandRepository<Person>
    {
        Task<Person> GetPersonByIdAsync(long id, CancellationToken cancellationToken);
    }
}
