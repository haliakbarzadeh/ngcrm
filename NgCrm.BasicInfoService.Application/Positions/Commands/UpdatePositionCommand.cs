using Goldiran.Framework.Application.Commands;
using MediatR;
using NgCrm.BasicInfoService.Domain.OrganizationHistories.Contracts;
using NgCrm.BasicInfoService.Domain.Positions.Contracts;
using NgCrm.BasicInfoService.Domain.Positions.Entities;
using NgCrm.BasicInfoService.Domain.Positions.Enums;

namespace NgCrm.BasicInfoService.Application.Positions.Commands
{
    public class UpdatePositionCommand : BaseCommandRequest, IRequest<bool>
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public long OrganizationId { get; set; }
        public long WorkspaceId { get; set; }
        public long? ParentId { get; set; }
        public PositionTypes PositionTypeId { get; set; }
        public bool IsActive { get; set; }

        public IEnumerable<long> PermissionIds { get; set; } = Enumerable.Empty<long>();
    }

    public class UpdatePositionCommandHandler : IRequestHandler<UpdatePositionCommand, bool>
    {
        private readonly IPositionCommandRepository _positionCommandRepository;
        private readonly IOrganizationHistoryCommandRepository _organizationHistoryCommandRepository;


        public UpdatePositionCommandHandler(IPositionCommandRepository positionCommandRepository,
            IOrganizationHistoryCommandRepository organizationHistoryCommandRepository)
        {
            _positionCommandRepository = positionCommandRepository;
            _organizationHistoryCommandRepository = organizationHistoryCommandRepository;
        }

        public async Task<bool> Handle(UpdatePositionCommand request, CancellationToken cancellationToken)
        {
            var position = await _positionCommandRepository.GetByIdAsync(request.Id, x => x.PositionPermissions);

            position.Update(request.Title, request.Name, request.ParentId, request.OrganizationId, request.WorkspaceId, request.PositionTypeId, request.IsActive);

            var positionPermissions = request.PermissionIds.Select(e => new PositionPermission(position.Id, e)).ToList();
            position.SetPositionPermissions(positionPermissions);

            _positionCommandRepository.Update(position);

            await _organizationHistoryCommandRepository.GenerateOrganizationHistory(cancellationToken);

            return (await _positionCommandRepository.UnitOfWork.SaveChangesAsync(cancellationToken)) > 0;
        }
    }
}
