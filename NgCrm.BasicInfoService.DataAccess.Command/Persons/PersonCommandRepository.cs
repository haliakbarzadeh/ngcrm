using Goldiran.Framework.EFCore.Repositories;
using Microsoft.EntityFrameworkCore;
using NgCrm.BasicInfoService.Domain.Persons.Contracts;
using NgCrm.BasicInfoService.Domain.Persons.Entities;
using NgCrm.BasicInfoService.Domain.Persons.ReadModels;

namespace NgCrm.BasicInfoService.DataAccess.Command.Persons
{
    public class PersonCommandRepository : CommandRepository<Person, BasicInfoCommandContext>, IPersonCommandRepository
    {
        public PersonCommandRepository(BasicInfoCommandContext dbContext) : base(dbContext)
        {
        }


        public async Task<Person> GetPersonByIdAsync(long id, CancellationToken cancellationToken)
        {
            var perosn = await EntitySet.Where(e => e.Id == id)
                .Include(e => e.PersonContacts)
                .Include(e => e.PersonAddresses)                
                .Include(e => e.PersonPositions).ThenInclude(e => e.PersonPositionPermissions)
                .FirstOrDefaultAsync();

            return perosn;
        }
    }
}
