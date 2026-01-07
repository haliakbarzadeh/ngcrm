using Mapster;
using MediatR;
using NgCrm.BasicInfoService.Domain.Workspaces.Contracts;
using NgCrm.BasicInfoService.Domain.Workspaces.Dtos;
using NgCrm.BasicInfoService.Domain.Workspaces.Queries;

namespace NgCrm.BasicInfoService.Application.Workspaces.Queries
{
    public class GetWorkspaceQueryHandler : IRequestHandler<GetWorkspaceQuery, IEnumerable<WorkspaceBriefDto>>
    {
        private readonly IWorkspaceQueryRepository _workspaceQueryRepository;
        private readonly IWorkspaceAuditService _workspaceAuditService;

        public GetWorkspaceQueryHandler(IWorkspaceQueryRepository workspaceQueryRepository, IWorkspaceAuditService workspaceAuditService)
        {
            _workspaceQueryRepository = workspaceQueryRepository;
            _workspaceAuditService = workspaceAuditService;
        }

        public async Task<IEnumerable<WorkspaceBriefDto>> Handle(GetWorkspaceQuery request, CancellationToken cancellationToken)
        {
            // test by babak. will be removed later
            //var tt = await _workspaceAuditService.GetPermissions(55, new DateTime(2025, 9, 13, 14, 45, 5), cancellationToken);

            var list = await _workspaceQueryRepository.GetAllAsync(cancellationToken, e => e.WorkspacePermissions);
            return list.Adapt<IEnumerable<WorkspaceBriefDto>>();
        }
    }
}
