using Goldiran.Framework.Application.Queries;
using MediatR;
using NgCrm.BasicInfoService.Domain.Workspaces.ReadModels;

namespace NgCrm.BasicInfoService.Domain.Workspaces.Queries
{
    public class GetWorkspaceByIdQuery : BaseQueryRequest, IRequest<WorkspaceReadModel?>
    {
        public long Id { get; set; }
    }
}
