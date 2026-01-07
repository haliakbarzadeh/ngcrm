using Goldiran.Framework.Domain.Dtos;
using Goldiran.Framework.Domain.Models;
using Goldiran.Framework.EFCore.Common;
using Goldiran.Framework.EFCore.Repositories;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NgCrm.BasicInfoService.Domain.AccessGroups.Contracts;
using NgCrm.BasicInfoService.Domain.AccessGroups.Dtos;
using NgCrm.BasicInfoService.Domain.AccessGroups.Queries;
using NgCrm.BasicInfoService.Domain.AccessGroups.ReadModels;
using NgCrm.BasicInfoService.Domain.Positions.Queries;

namespace NgCrm.BasicInfoService.DataAccess.Query.AccessGroups
{
    public class AccessGroupQueryRepository : QueryRepository<AccessGroupReadModel, BasicInfoQueryContext>, IAccessGroupQueryRepository
    {
        public AccessGroupQueryRepository(BasicInfoQueryContext dbContext) : base(dbContext)
        {
        }

        public async Task<Paged<AccessGroupBriefDto>> GetPagedByFilterAsync(GetAccessGroupQuery getAccessGroupQuery, 
            CancellationToken cancellationToken)
        {
            var query = EntitySet.AsQueryable();

            if (!getAccessGroupQuery.SearchTerm.IsNullOrEmpty())
            {
                query = query.Where(e => e.Title.Contains(getAccessGroupQuery.SearchTerm) ||
                        e.Name.Contains(getAccessGroupQuery.SearchTerm)).AsQueryable();
            }

            var list = await query.ProjectToType<AccessGroupBriefDto>().ToPagedListAsync(getAccessGroupQuery.FilterInfo, cancellationToken);
            return list;
        }


        public async Task<IEnumerable<SelectItemDto>> GetAccessGroupsSelectListAsync(GetAccessGroupsSelectListQuery getAccessGroupsSelectListQuery, CancellationToken cancellationToken)
        {
            var query = EntitySet.AsQueryable();

            if (!getAccessGroupsSelectListQuery.SearchTerm.IsNullOrEmpty())
            {
                query = query.Where(e => e.Title.Contains(getAccessGroupsSelectListQuery.SearchTerm) ||
                        e.Name.Contains(getAccessGroupsSelectListQuery.SearchTerm)).AsQueryable();
            }          

            return await query.Select(e => new SelectItemDto
            {
                Title = e.Title,
                Id = e.Id,
                Tag = e.Name
            }).ToListAsync(); ;
        }
    }
}
