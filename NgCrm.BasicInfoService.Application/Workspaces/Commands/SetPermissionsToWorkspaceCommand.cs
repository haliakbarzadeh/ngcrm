using Goldiran.Framework.Application.Commands;
using MediatR;
using NgCrm.BasicInfoService.Domain.Workspaces.Contracts;
using NgCrm.BasicInfoService.Domain.Workspaces.Entities;

namespace NgCrm.BasicInfoService.Application.Workspaces.Commands
{
    public class SetPermissionsToWorkspaceCommand : BaseCommandRequest, IRequest<bool>
    {
        public long WorkspaceId { get; set; }
        public IEnumerable<long> PermissionIds { get; set; } = Enumerable.Empty<long>();
    }

    public class SetPermissionsToWorkspaceCommandHandler : IRequestHandler<SetPermissionsToWorkspaceCommand, bool>
    {
        private readonly IWorkspaceCommandRepository _workspaceCommandRepository;

        public SetPermissionsToWorkspaceCommandHandler(IWorkspaceCommandRepository workspaceCommandRepository)
        {
            _workspaceCommandRepository = workspaceCommandRepository;
        }

        public async Task<bool> Handle(SetPermissionsToWorkspaceCommand request, CancellationToken cancellationToken)
        {
            var workspace = await _workspaceCommandRepository.GetByIdAsync(request.WorkspaceId, e => e.WorkspacePermissions);


            var workspacePermissions = request.PermissionIds.Select(e => new WorkspacePermission(request.WorkspaceId, e)).ToList();

            workspace.SetWorkspacePermissions(workspacePermissions);

            _workspaceCommandRepository.Update(workspace);

            var result = await _workspaceCommandRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return result > 0;
        }
    }
}
