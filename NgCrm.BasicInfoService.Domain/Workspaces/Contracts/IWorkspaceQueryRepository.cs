using Goldiran.Framework.Domain.Contracts;
using NgCrm.BasicInfoService.Domain.Workspaces.ReadModels;

namespace NgCrm.BasicInfoService.Domain.Workspaces.Contracts
{
    public interface IWorkspaceQueryRepository : IQueryRepository<WorkspaceReadModel>
    {
        Task<bool> IsTitleUniqueAsync(string title, CancellationToken cancellationToken, long id = 0);
    }
}
