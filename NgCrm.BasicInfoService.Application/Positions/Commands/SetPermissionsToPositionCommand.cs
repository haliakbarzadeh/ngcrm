using Goldiran.Framework.Application.Commands;
using MediatR;
using NgCrm.BasicInfoService.Domain.Positions.Contracts;
using NgCrm.BasicInfoService.Domain.Positions.Entities;

namespace NgCrm.BasicInfoService.Application.Positions.Commands
{
    public class SetPermissionsToPositionCommand : BaseCommandRequest, IRequest<bool>
    {
        public long PositionId { get; set; }
        public IEnumerable<long> PermissionIds { get; set; } = Enumerable.Empty<long>();
    }

    public class SetPermissionsToPositionCommandHandler : IRequestHandler<SetPermissionsToPositionCommand, bool>
    {
        private readonly IPositionCommandRepository _positionCommandRepository;

        public SetPermissionsToPositionCommandHandler(IPositionCommandRepository positionCommandRepository)
        {
            _positionCommandRepository = positionCommandRepository;
        }

        public async Task<bool> Handle(SetPermissionsToPositionCommand request, CancellationToken cancellationToken)
        {
            var position = await _positionCommandRepository.GetByIdAsync(request.PositionId, e => e.PositionPermissions);

            var positionPermissions = request.PermissionIds.Select(e => new PositionPermission(request.PositionId, e)).ToList();

            position.SetPositionPermissions(positionPermissions);

            _positionCommandRepository.Update(position);

            var result = await _positionCommandRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return result > 0;
        }
    }
}
