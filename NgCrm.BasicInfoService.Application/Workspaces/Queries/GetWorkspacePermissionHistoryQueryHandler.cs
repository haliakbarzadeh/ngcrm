using MediatR;
using NgCrm.BasicInfoService.Domain.Workspaces.Contracts;
using NgCrm.BasicInfoService.Domain.Workspaces.Queries;

namespace NgCrm.BasicInfoService.Application.Workspaces.Queries
{
    public class GetWorkspacePermissionHistoryQueryHandler : IRequestHandler<GetWorkspacePermissionHistoryQuery, IEnumerable<long>>
    {
        private readonly IWorkspaceAuditService _workspaceAuditService;

        public GetWorkspacePermissionHistoryQueryHandler(IWorkspaceAuditService workspaceAuditService)
        {
            _workspaceAuditService = workspaceAuditService;
        }

        public async Task<IEnumerable<long>> Handle(GetWorkspacePermissionHistoryQuery request, CancellationToken cancellationToken)
        {
            return await _workspaceAuditService.GetPermissions(request.WorkspaceId, request.TargetDate, cancellationToken);
        }
    }
}