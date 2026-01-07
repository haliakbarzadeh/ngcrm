using Goldiran.Framework.Application.Commands;
using MediatR;
using NgCrm.BasicInfoService.Domain.Roles.Contracts;
using NgCrm.BasicInfoService.Domain.Roles.Entities;

namespace NgCrm.BasicInfoService.Application.Roles.Commands
{
    public class CreateRoleCommand : BaseCommandRequest, IRequest<bool>
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public long? ParentId { get; set; }
    }

    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, bool>
    {
        private readonly IRoleCommandRepository _roleCommandRepository;

        public CreateRoleCommandHandler(IRoleCommandRepository roleCommandRepository)
        {
            _roleCommandRepository = roleCommandRepository;
        }

        public async Task<bool> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var entity = new Role(request.Title, request.Name, request.ParentId);

            _roleCommandRepository.Add(entity);

            await _roleCommandRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
