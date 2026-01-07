using Goldiran.Framework.EFCore.Repositories;
using NgCrm.BasicInfoService.Domain.Workspaces.Contracts;
using NgCrm.BasicInfoService.Domain.Workspaces.Entities;

namespace NgCrm.BasicInfoService.DataAccess.Command.Workspaces
{
    public class WorkspaceCommandRepository : CommandRepository<Workspace, BasicInfoCommandContext>, IWorkspaceCommandRepository
    {
        public WorkspaceCommandRepository(BasicInfoCommandContext dbContext) : base(dbContext)
        {
        }
    }
}
