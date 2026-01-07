using Goldiran.Framework.EFCore.Common;
using Goldiran.Framework.EFCore.Repositories;
using Mapster;
using Microsoft.EntityFrameworkCore;
using NgCrm.BasicInfoService.Domain.PersonAccessGroups.Contracts;
using NgCrm.BasicInfoService.Domain.PersonAccessGroups.Dtos;
using NgCrm.BasicInfoService.Domain.PersonAccessGroups.ReadModels;

namespace NgCrm.BasicInfoService.DataAccess.Query.PersonAccessGroups
{
    public class PersonAccessGroupQueryRepository : QueryRepository<PersonAccessGroupReadModel, BasicInfoQueryContext>, IPersonAccessGroupQueryRepository
    {
        public PersonAccessGroupQueryRepository(BasicInfoQueryContext context) : base(context)
        {
        }

        public async Task<IEnumerable<PersonAccessGroupReadModel>> GetByAccessGroupIdAsync(long accessGroupId, CancellationToken cancellationToken)
        {
            var query = EntitySet
                .Where(e => e.AccessGroupId == accessGroupId)
                .Include(e => e.Person).AsQueryable();            

            return await query.ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<PersonAccessGroupReadModel>> GetByPersonIdAsync(long personId, CancellationToken cancellationToken)
        {
            var query = EntitySet
               .Where(e => e.PersonId == personId)
               .Where(e => e.AccessGroup.IsActive == true)
               .Include(e=>e.AccessGroup)
               .Include(e=>e.Person)
               .AsQueryable();

            return await query.ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<PersonAccessGroupBriefDto>> GetPersonAccessGroupBriefDtosAsync( CancellationToken cancellationToken)
        {
            return await EntitySet.Include(e => e.Person).Include(e => e.AccessGroup).ProjectToType<PersonAccessGroupBriefDto>().ToListAsync(cancellationToken); ;
        }
    }
}