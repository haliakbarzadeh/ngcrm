using MediatR;
using NgCrm.BasicInfoService.Domain.Workspaces.Contracts;
using NgCrm.BasicInfoService.Domain.Workspaces.Entities;
using NgCrm.BasicInfoService.Domain.Workspaces.Queries;
using NgCrm.BasicInfoService.Domain.Workspaces.ReadModels;

namespace NgCrm.BasicInfoService.Application.Workspaces.Queries
{
    public class GetWorkspaceByIdQueryHandler : IRequestHandler<GetWorkspaceByIdQuery, WorkspaceReadModel?>
    {
        private readonly IWorkspaceQueryRepository _workspaceQueryRepository;

        public GetWorkspaceByIdQueryHandler(IWorkspaceQueryRepository workspaceQueryRepository)
        {
            _workspaceQueryRepository = workspaceQueryRepository;
        }

        public async Task<WorkspaceReadModel?> Handle(GetWorkspaceByIdQuery request, CancellationToken cancellationToken)
        {
            var workspace = await _workspaceQueryRepository.GetByIdAsync(request.Id, cancellationToken, e => e.WorkspacePermissions);

            if (workspace is null)
                throw new KeyNotFoundException("فضای کاری یافت نشد.");

            return workspace;
        }
    }
}
