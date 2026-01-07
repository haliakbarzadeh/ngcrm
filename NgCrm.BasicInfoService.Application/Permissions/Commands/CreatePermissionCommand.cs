using Goldiran.Framework.Application.Commands;
using MediatR;
using NgCrm.BasicInfoService.Domain.Permissions.Contracts;
using NgCrm.BasicInfoService.Domain.Permissions.Entities;
using NgCrm.BasicInfoService.Domain.Permissions.Enums;

namespace NgCrm.BasicInfoService.Application.Permissions.Commands
{
    public class CreatePermissionCommand : BaseCommandRequest, IRequest<bool>
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public long ParentId { get; set; }
        public PermissionTypes PermissionTypeId { get; set; }
        public int? SortOrder { get; set; }
        public string Route { get; set; }
        public string Icon { get; set; }
    }

    public class CreatePermissionCommandHandler : IRequestHandler<CreatePermissionCommand, bool>
    {
        private readonly IPermissionCommandRepository _permissionCommandRepository;

        public CreatePermissionCommandHandler(IPermissionCommandRepository permissionCommandRepository)
        {
            _permissionCommandRepository = permissionCommandRepository;
        }

        public async Task<bool> Handle(CreatePermissionCommand request, CancellationToken cancellationToken)
        {
            var permission = new Permission(request.Title, request.Name, request.ParentId, request.PermissionTypeId, request.SortOrder, request.Route, request.Icon);

            _permissionCommandRepository.Add(permission);
            var result = await _permissionCommandRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return result > 0;
        }
    }
}
