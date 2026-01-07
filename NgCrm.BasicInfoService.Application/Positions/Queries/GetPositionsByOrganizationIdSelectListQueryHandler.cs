using Goldiran.Framework.Domain.Dtos;
using MediatR;
using NgCrm.BasicInfoService.Domain.Positions.Contracts;
using NgCrm.BasicInfoService.Domain.Positions.Queries;

namespace NgCrm.BasicInfoService.Application.Positions.Queries
{
    public class GetPositionsByOrganizationIdSelectListQueryHandler : IRequestHandler<GetPositionsByOrganizationIdSelectListQuery, IEnumerable<SelectItemDto>>
    {
        private readonly IPositionQueryRepository _positionQueryRepository;

        public GetPositionsByOrganizationIdSelectListQueryHandler(IPositionQueryRepository positionQueryRepository)
        {
            _positionQueryRepository = positionQueryRepository;
        }

        public async Task<IEnumerable<SelectItemDto>> Handle(GetPositionsByOrganizationIdSelectListQuery request, CancellationToken cancellationToken)
        {
            var list = await _positionQueryRepository.GetPositionsByOrganizationIdSelectListAsync(request.OrganizationId, cancellationToken);
            return list;
        }
    }
}
