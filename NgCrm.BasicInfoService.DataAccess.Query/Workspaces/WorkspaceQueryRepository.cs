using Goldiran.Framework.EFCore.Repositories;
using Microsoft.EntityFrameworkCore;
using NgCrm.BasicInfoService.Domain.Workspaces.Contracts;
using NgCrm.BasicInfoService.Domain.Workspaces.ReadModels;

namespace NgCrm.BasicInfoService.DataAccess.Query.Workspaces
{
    public class WorkspaceQueryRepository : QueryRepository<WorkspaceReadModel, BasicInfoQueryContext>, IWorkspaceQueryRepository
    {
        public WorkspaceQueryRepository(BasicInfoQueryContext dbContext) : base(dbContext)
        {

        }

        public async Task<bool> IsTitleUniqueAsync(string title, CancellationToken cancellationToken, long id = 0)
        {
            return !await EntitySet
                .Where(e => e.Title == title && (id == 0 || e.Id != id))
                .AnyAsync(cancellationToken);
        }
    }
}
