using Goldiran.Framework.EFCore.Repositories;
using NgCrm.BasicInfoService.Domain.PersonDelegates.Contracts;
using NgCrm.BasicInfoService.Domain.PersonDelegates.Entities;

namespace NgCrm.BasicInfoService.DataAccess.Command.PersonDelegates
{
    public class PersonDelegateCommandRepository : CommandRepository<PersonDelegate, BasicInfoCommandContext>, IPersonDelegateCommandRepository
    {
        public PersonDelegateCommandRepository(BasicInfoCommandContext dbContext) : base(dbContext)
        {
        }
    }
}