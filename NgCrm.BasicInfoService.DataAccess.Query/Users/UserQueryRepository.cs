using Goldiran.Framework.Domain.Dtos;
using Goldiran.Framework.Domain.Models;
using Goldiran.Framework.EFCore.Common;
using Goldiran.Framework.EFCore.Repositories;
using Mapster;
using Microsoft.EntityFrameworkCore;
using NgCrm.BasicInfoService.Domain.Users.Contracts;
using NgCrm.BasicInfoService.Domain.Users.Dtos;
using NgCrm.BasicInfoService.Domain.Users.Queries;
using NgCrm.BasicInfoService.Domain.Users.ReadModels;

namespace NgCrm.BasicInfoService.DataAccess.Query.Users
{
    public class UserQueryRepository : QueryRepository<UserReadModel, BasicInfoQueryContext>, IUserQueryRepository
    {
        public UserQueryRepository(BasicInfoQueryContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<UserReadModel>> GetByIdsAsync(IEnumerable<long> userIds, CancellationToken cancellationToken)
        {
            var list = await EntitySet
                .Where(e => e.ADUserId != null)
                .Where(e => userIds.Contains(e.Id))
                .ToListAsync(cancellationToken);

            return list;
        }

        public async Task<Paged<UserBriefDto>> GetPagedByFilterAsync(GetUserQuery getUserQuery, CancellationToken cancellationToken)
        {
            var query = this.EntitySet.AsQueryable();


            if (getUserQuery.IsActive != null)
                query = query.Where(e => e.IsActive == getUserQuery.IsActive);

            if (getUserQuery.IsADActive != null)
                query = query.Where(e => e.IsADActive == getUserQuery.IsADActive);

            if (getUserQuery.AccountTypeId.HasValue)
                query = query.Where(e => e.AccountTypeId == getUserQuery.AccountTypeId);

            if (!String.IsNullOrEmpty(getUserQuery.SearchTerm))
                query = query.Where(e =>
                e.Person.NationalCode.Contains(getUserQuery.SearchTerm) ||
                e.Username.Contains(getUserQuery.SearchTerm) ||
                (e.Person.FirstName + " " + e.Person.LastName).Contains(getUserQuery.SearchTerm));

            var list = await query.ProjectToType<UserBriefDto>().ToPagedListAsync(getUserQuery.FilterInfo, cancellationToken);

            return list;
        }

        public async Task<UserReadModel> GetByUserNameAsync(string userName, CancellationToken cancellationToken)
        {
            var user = await EntitySet.Where(u => u.Username == userName && u.Person.IsActive == true)
                .Include(x => x.Person)
                .ThenInclude(x => x.PersonPositions.Where(p => p.IsActive && (!p.EndDate.HasValue || p.EndDate > DateTime.Now)))
                .ThenInclude(x => x.Position.Organization)
                .FirstOrDefaultAsync(cancellationToken);

            return user;
        }

        public async Task<IEnumerable<SelectItemDto>> GetPositionsByUserIdAsync(long userId, CancellationToken cancellationToken)
        {
            var selectItemDtos = await EntitySet.Where(u => u.Id == userId && u.Person.IsActive == true)
                .Include(x => x.Person)
                .ThenInclude(x => x.PersonPositions)
                .SelectMany(e =>
                    e.Person.PersonPositions
                    .Where(p => p.IsActive && (!p.EndDate.HasValue || p.EndDate > DateTime.Now))
                    .Select(e => new SelectItemDto
                    {
                        Id = e.PositionId,
                        Title = e.Position.Title,
                        Tag = e.Position.Name
                    }).ToList()
                ).ToListAsync(cancellationToken);


            return selectItemDtos;
        }

        public async Task<UserReadModel?> GetByIdAsync(long userId, CancellationToken cancellationToken)
        {
            var user = await EntitySet
                .Where(e => e.Id == userId)
                .Include(x => x.Person)
                .FirstOrDefaultAsync(cancellationToken);

            return user;
        }

        public async Task<IEnumerable<SelectItemDto>> GetUserSelectList(GetUserSelectListQuery request, CancellationToken cancellationToken)
        {
            var query = EntitySet.Include(x => x.Person).AsNoTracking();

            if (!string.IsNullOrEmpty(request.SearchTerm))
            {
                query = query.Where(e => e.Username.Contains(request.SearchTerm));
            }

            var users = await query.Take(20).Select(e => new SelectItemDto
            {
                Id = e.Id,
                Title = e.Username,
                Tag = $"{e.Person.FirstName} {e.Person.LastName}"
            }).ToListAsync(cancellationToken);


            return users;
        }
    }
}
