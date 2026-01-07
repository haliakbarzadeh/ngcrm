using Goldiran.Framework.Application.Commands;
using MediatR;
using NgCrm.BasicInfoService.Domain.Workspaces.Contracts;

namespace NgCrm.BasicInfoService.Application.Workspaces.Commands
{
    public class DeleteWorkspaceCommand : BaseCommandRequest, IRequest<bool>
    {
        public long Id { get; set; }
    }

    public class DeleteWorkspaceCommandHandler : IRequestHandler<DeleteWorkspaceCommand, bool>
    {
        private readonly IWorkspaceCommandRepository _workspaceCommandRepository;

        public DeleteWorkspaceCommandHandler(IWorkspaceCommandRepository workspaceCommandRepository)
        {
            _workspaceCommandRepository = workspaceCommandRepository;
        }

        public async Task<bool> Handle(DeleteWorkspaceCommand request, CancellationToken cancellationToken)
        {
            var workspace = await _workspaceCommandRepository.GetByIdAsync(request.Id);

            workspace.Archive();

            _workspaceCommandRepository.Update(workspace);
            var result = await _workspaceCommandRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return result > 0;
        }
    }
}
