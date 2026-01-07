using Goldiran.Framework.Domain.Models;
using Goldiran.Framework.EFCore.Common;
using Goldiran.Framework.EFCore.Repositories;
using Microsoft.EntityFrameworkCore;
using NgCrm.BasicInfoService.Domain.PersonDelegates.Contracts;
using NgCrm.BasicInfoService.Domain.PersonDelegates.Queries;
using NgCrm.BasicInfoService.Domain.PersonDelegates.ReadModels;

namespace NgCrm.BasicInfoService.DataAccess.Query.PersonDelegates
{
    public class PersonDelegateQueryRepository : QueryRepository<PersonDelegateReadModel, BasicInfoQueryContext>, IPersonDelegateQueryRepository
    {
        public PersonDelegateQueryRepository(BasicInfoQueryContext dbContext) : base(dbContext)
        {
        }

        public async Task<Paged<PersonDelegateReadModel>> GetPagedByFilterAsync(GetPersonDelegateQuery request, CancellationToken cancellationToken)
        {
            var query = EntitySet.AsQueryable();

            if (!String.IsNullOrEmpty(request.SearchTerm))
                query = query.Where(x => (x.AssignerPerson.FirstName + " " + x.AssignerPerson.FirstName).Contains(request.SearchTerm) ||
                                         (x.DelegatePerson.FirstName + " " + x.DelegatePerson.FirstName).Contains(request.SearchTerm));
           
            if (request.FromDate.HasValue)
                query = query.Where(x => x.FromDate >= request.FromDate.Value);

            if (request.ToDate.HasValue)
                query = query.Where(x => x.ToDate <= request.ToDate.Value);

            if (request.ReasonTypeId.HasValue)
                query = query.Where(x => x.ReasonTypeId == request.ReasonTypeId.Value);

            if (request.PositionId.HasValue)
                query = query.Where(x => x.AssignerPositionId == request.PositionId.Value);

            var list = await query
                .Include(x => x.AssignerPerson)
                .Include(x => x.AssignerPosition)
                .Include(x => x.CreatePerson)
                .Include(x => x.DelegatePerson).OrderByDescending(e => e.Id).ToPagedListAsync(request.FilterInfo, cancellationToken);

            return list;
        }
    }
}