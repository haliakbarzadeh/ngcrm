using Goldiran.Framework.EFCore.Common;
using Goldiran.Framework.EFCore.Repositories;
using Microsoft.EntityFrameworkCore;
using NgCrm.BasicInfoService.Domain.PersonAccessGroups.Contracts;
using NgCrm.BasicInfoService.Domain.PersonAccessGroups.Entities;

namespace NgCrm.BasicInfoService.DataAccess.Command.PersonAccessGroups
{
    public class PersonAccessGroupCommandRepository : CommandRepository<PersonAccessGroup, BasicInfoCommandContext>, IPersonAccessGroupCommandRepository
    {
        public PersonAccessGroupCommandRepository(BasicInfoCommandContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<PersonAccessGroup>> GetByAccessGroupIdAsync(long accessGroupId, CancellationToken cancellationToken)
        {
            var list = await EntitySet
                .Where(e => e.AccessGroupId == accessGroupId)
                .ToListAsync(cancellationToken);

            return list;
        }

        public async Task<IEnumerable<PersonAccessGroup>> GetByPersonIdAsync(long accessGroupId, CancellationToken cancellationToken)
        {
            var list = await EntitySet
                .Where(e => e.AccessGroupId == accessGroupId)
                .ToListAsync(cancellationToken);

            return list;
        }
    }
}