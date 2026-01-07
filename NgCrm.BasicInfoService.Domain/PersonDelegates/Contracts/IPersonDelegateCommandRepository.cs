using Goldiran.Framework.Domain.Contracts;
using NgCrm.BasicInfoService.Domain.PersonDelegates.Entities;

namespace NgCrm.BasicInfoService.Domain.PersonDelegates.Contracts
{
    public interface IPersonDelegateCommandRepository : ICommandRepository<PersonDelegate>
    {
    }
}