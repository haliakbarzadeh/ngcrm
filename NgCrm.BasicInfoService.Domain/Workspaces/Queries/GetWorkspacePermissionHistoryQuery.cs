using Goldiran.Framework.Application.Queries;
using MediatR;

namespace NgCrm.BasicInfoService.Domain.Workspaces.Queries
{
    public class GetWorkspacePermissionHistoryQuery : BaseQueryRequest, IRequest<IEnumerable<long>>
    {
        public long WorkspaceId { get; set; }
        public DateTime TargetDate { get; set; } = DateTime.Now;
    }
}