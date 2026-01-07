using Goldiran.Framework.Domain.Dtos;
using Goldiran.Framework.Domain.Models;
using Goldiran.Framework.EFCore.Common;
using Goldiran.Framework.EFCore.Repositories;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NgCrm.BasicInfoService.Domain.Persons.Contracts;
using NgCrm.BasicInfoService.Domain.Persons.Dtos;
using NgCrm.BasicInfoService.Domain.Persons.Queries;
using NgCrm.BasicInfoService.Domain.Persons.ReadModels;
using NgCrm.BasicInfoService.Domain.Positions.ReadModels;

namespace NgCrm.BasicInfoService.DataAccess.Query.Persons
{
    public class PersonQueryRepository : QueryRepository<PersonReadModel, BasicInfoQueryContext>, IPersonQueryRepository
    {
        public PersonQueryRepository(BasicInfoQueryContext dbContext) : base(dbContext)
        {

        }

        public async Task<Paged<PersonBriefDto>> GetPagedByFilterAsync(GetPersonQuery getPersonQuery,
            CancellationToken cancellationToken)
        {

            var query = this.EntitySet.AsQueryable();

            if (!string.IsNullOrEmpty(getPersonQuery.NationalCode))
                query = query.Where(e => e.NationalCode == getPersonQuery.NationalCode);

            if (!string.IsNullOrEmpty(getPersonQuery.FirstName))
                query = query.Where(e => e.FirstName.Contains(getPersonQuery.FirstName));

            if (!string.IsNullOrEmpty(getPersonQuery.LastName))
                query = query.Where(e => e.LastName.Contains(getPersonQuery.LastName));

            if (!string.IsNullOrEmpty(getPersonQuery.PersonalCode))
                query = query.Where(e => e.PersonalCode == getPersonQuery.PersonalCode);

            if (getPersonQuery.IsActive is not null)
                query = query.Where(e => e.IsActive == getPersonQuery.IsActive);

            var list = await query
                .ProjectToType<PersonBriefDto>()
                .ToPagedListAsync(getPersonQuery.FilterInfo, cancellationToken);

            return list;
        }

        public async Task<IEnumerable<PersonReadModel>> GetByPositionIdAsync(long id, CancellationToken cancellationToken)
        {
            return await EntitySet.Where(e => e.PersonPositions.Any(q => q.Id == id && q.IsDeleted != true)).ToListAsync();
        }

        public async Task<PersonReadModel> GetPersonByIdAsync(long id, CancellationToken cancellationToken, long? positionId = null)
        {
            var perosn = await EntitySet.Where(e => e.Id == id)
                .Where(e => positionId == null || e.PersonPositions.Any(p => p.PositionId == positionId))
                .Include(e => e.PersonContacts)
                .Include(e => e.PersonAddresses)
                .Include(e => e.PersonPositions).ThenInclude(e => e.PersonPositionPermissions)
                .Include(e => e.PersonPositions).ThenInclude(e => e.Position).ThenInclude(e => e.PositionPermissions)
                .FirstOrDefaultAsync();

            return perosn;
        }

        public async Task<IEnumerable<SelectItemDto>> GetPersonSelectListAsync(GetPersonSelectListQuery request, CancellationToken cancellationToken)
        {
            var query = EntitySet.AsQueryable();

            if (!request.SearchTerm.IsNullOrEmpty())
            {
                query = query.Where(e => (e.FirstName + " " + e.LastName).Contains(request.SearchTerm) ||
                        e.NationalCode == request.SearchTerm ||
                        e.PersonalCode == request.SearchTerm ||
                        (e.FirstName + " " + e.LastName).Contains(request.SearchTerm)).AsQueryable();
            }

            return await query.ProjectToType<SelectItemDto>().Take(request.Take).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<SelectItemDto>> GetPositionsByPersonIdAsync(long personId, CancellationToken cancellationToken)
        {
            var result = await DbContext.Set<PersonPositionReadModel>().AsNoTracking()
                .Where(p => p.PersonId == personId && p.IsDeleted != true && p.IsActive)
                .ProjectToType<SelectItemDto>().ToListAsync();

            return result;
        }

        public async Task<IEnumerable<SelectItemDto>> GetMyChildPersonsAsync(long positionId, CancellationToken cancellationToken)
        {
            // Get all child position IDs recursively

            //var childPositionIds = await GetChildPositionIdsRecursiveAsync(positionId, cancellationToken);
            var childPositionIds = await GetChildPositionIdsAsync(positionId, cancellationToken);

            if (!childPositionIds.Any())
                return Enumerable.Empty<SelectItemDto>();

            // Get persons who have active positions in child positions
            var query = EntitySet.AsNoTracking()
                .Where(p => p.IsActive == true)
                .Where(p => p.PersonPositions.Any(pp =>
                    pp.IsActive &&
                    childPositionIds.Contains(pp.PositionId) &&
                    (!pp.EndDate.HasValue || pp.EndDate > DateTime.Now)));

            return await query.ProjectToType<SelectItemDto>().OrderBy(s => s.Title).ToListAsync(cancellationToken);
        }

        private async Task<List<long>> GetChildPositionIdsAsync(long parentPositionId, CancellationToken cancellationToken)
        {
            var allChildIds = new List<long>();

            var allPositions = await DbContext.Set<PositionReadModel>()
                .Select(p => new { p.Id, p.ParentId })
                .ToListAsync(cancellationToken);

            void AddChildren(long id)
            {
                allChildIds.Add(id);
                var children = allPositions.Where(p => p.ParentId == id).ToList();
                foreach (var child in children)
                {
                    AddChildren(child.Id);
                }
            }

            AddChildren(parentPositionId);

            return allChildIds;
        }

        private async Task<List<long>> GetChildPositionIdsRecursiveAsync(long parentPositionId, CancellationToken cancellationToken)
        {
            var allChildIds = new List<long>() { parentPositionId };

            // Get direct children
            var directChildren = await DbContext.Set<PositionReadModel>()
                .Where(p => p.ParentId == parentPositionId)
                .Select(p => p.Id)
                .ToListAsync(cancellationToken);

            foreach (var childId in directChildren)
            {
                allChildIds.Add(childId);
                // Recursively get children of this child
                var grandChildren = await GetChildPositionIdsRecursiveAsync(childId, cancellationToken);
                allChildIds.AddRange(grandChildren);
            }

            return allChildIds;
        }


        public async Task<IEnumerable<PersonSummaryDto>> GetGetPersonSummaryAsync(GetPersonSummaryQuery request, CancellationToken cancellationToken)
        {
            var query = EntitySet.AsQueryable();

            if (!request.SearchTerm.IsNullOrEmpty())
            {
                query = query.Where(e => (e.FirstName + " " + e.LastName).Contains(request.SearchTerm) ||
                        e.NationalCode == request.SearchTerm ||
                        e.PersonalCode == request.SearchTerm ||
                        (e.FirstName + " " + e.LastName).Contains(request.SearchTerm)).AsQueryable();
            }

            return await query.Take(request.Take).ProjectToType<PersonSummaryDto>().ToListAsync(cancellationToken);
        }
    }
}
