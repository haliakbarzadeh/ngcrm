using Goldiran.Framework.Domain.Dtos;
using Goldiran.Framework.Domain.Models;
using Goldiran.Framework.EFCore.Common;
using Goldiran.Framework.EFCore.Repositories;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NgCrm.BasicInfoService.Domain.ADUsers.Contracts;
using NgCrm.BasicInfoService.Domain.ADUsers.Queries;
using NgCrm.BasicInfoService.Domain.ADUsers.ReadModels;

namespace NgCrm.BasicInfoService.DataAccess.Query.ADUsers
{
    public class ADUserQueryRepository : QueryRepository<ADUserReadModel, BasicInfoQueryContext>, IADUserQueryRepository
    {
        public ADUserQueryRepository(BasicInfoQueryContext dbContext) : base(dbContext)
        {
        }

        public async Task<Paged<ADUserReadModel>> GetPagedByFilterAsync(GetADUserQuery getADUserQuery, CancellationToken cancellationToken)
        {
            var query = this.EntitySet.Where(e => e.IsActive == true).AsQueryable();

            if (!string.IsNullOrEmpty(getADUserQuery.Username))
                query = query.Where(e => e.UserName.Contains(getADUserQuery.Username));

            if (!string.IsNullOrEmpty(getADUserQuery.FirstName))
                query = query.Where(e => e.FirstName.Contains(getADUserQuery.FirstName));

            if (!string.IsNullOrEmpty(getADUserQuery.LastName))
                query = query.Where(e => e.LastName.Contains(getADUserQuery.LastName));

            return await query.ToPagedListAsync(getADUserQuery.FilterInfo, cancellationToken); ;
        }

        public async Task<IEnumerable<SelectItemDto>> GetADUserSelectListAsync(GetADUserSelectListQuery request, CancellationToken cancellationToken)
        {
            var query = EntitySet.AsQueryable();

            if (!request.SearchTerm.IsNullOrEmpty())
            {
                query = query.Where(e => e.DisplayName.Contains(request.SearchTerm) ||
                e.UserName.Contains(request.SearchTerm)).AsQueryable();
            }

            return await query.Take(request.Take).ProjectToType<SelectItemDto>().ToListAsync(cancellationToken);
        }
    }
}
