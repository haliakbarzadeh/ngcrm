using Mapster;
using MediatR;
using NgCrm.BasicInfoService.Domain.Positions.Contracts;
using NgCrm.BasicInfoService.Domain.Positions.Dtos;
using NgCrm.BasicInfoService.Domain.Positions.Queries;

namespace NgCrm.BasicInfoService.Application.Positions.Queries
{
    public class GetPositionByIdQueryHandler : IRequestHandler<GetPositionByIdQuery, PositionDto>
    {
        private readonly IPositionQueryRepository _positionQueryRepository;

        public GetPositionByIdQueryHandler(IPositionQueryRepository positionQueryRepository)
        {
            _positionQueryRepository = positionQueryRepository;
        }

        public async Task<PositionDto> Handle(GetPositionByIdQuery request, CancellationToken cancellationToken)
        {
            var position = await _positionQueryRepository.GetByIdAsync(request.Id, cancellationToken, e => e.PositionPermissions, e => e.Organization, e => e.Workspace);

            if (position is null)
                throw new KeyNotFoundException("سمت مورد نظر یافت نشد.");

            var positionDto = position.Adapt<PositionDto>();

            if (positionDto.ParentId is not null)
            {
                var parentPosition = await _positionQueryRepository.GetByIdAsync((long)positionDto.ParentId, cancellationToken, e => e.Organization);

                positionDto.ParentOrganizationId = parentPosition.OrganizationId;
                positionDto.ParentOrganizationTitle = parentPosition.Organization.Title;
            }

            return positionDto;
        }
    }
}
