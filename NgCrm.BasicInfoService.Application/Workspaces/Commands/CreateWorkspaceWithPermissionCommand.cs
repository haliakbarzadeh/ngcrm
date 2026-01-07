using Goldiran.Framework.Application.Commands;
using MediatR;
using NgCrm.BasicInfoService.Domain.Workspaces.Contracts;
using NgCrm.BasicInfoService.Domain.Workspaces.Entities;

namespace NgCrm.BasicInfoService.Application.Workspaces.Commands
{
    public class CreateWorkspaceWithPermissionCommand : BaseCommandRequest, IRequest<bool>
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<long> PermissionIds { get; set; } = Enumerable.Empty<long>();

    }

    public class CreateWorkspaceWithPermissionCommandHandler : IRequestHandler<CreateWorkspaceWithPermissionCommand, bool>
    {
        private readonly IWorkspaceCommandRepository _workspaceCommandRepository;

        public CreateWorkspaceWithPermissionCommandHandler(IWorkspaceCommandRepository workspaceCommandRepository)
        {
            _workspaceCommandRepository = workspaceCommandRepository;
        }

        public async Task<bool> Handle(CreateWorkspaceWithPermissionCommand request, CancellationToken cancellationToken)
        {
            var workspace = new Workspace(request.Title, request.Name, request.Description);

            var workspacePermissions = request.PermissionIds.Select(e => new WorkspacePermission(workspace.Id, e)).ToList();
            workspace.SetWorkspacePermissions(workspacePermissions);

            _workspaceCommandRepository.Add(workspace);
            var result = await _workspaceCommandRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return result > 0;
        }
    }
}
