using Goldiran.Framework.Domain.Models;
using Mapster;
using MediatR;
using NgCrm.BasicInfoService.Domain.Positions.Contracts;
using NgCrm.BasicInfoService.Domain.Positions.Dtos;
using NgCrm.BasicInfoService.Domain.Positions.Queries;

namespace NgCrm.BasicInfoService.Application.Positions.Queries
{
    public class GetPositionQueryHandler : IRequestHandler<GetPositionQuery, Paged<PositionBriefDto>>
    {
        private readonly IPositionQueryRepository _positionQueryRepository;

        public GetPositionQueryHandler(IPositionQueryRepository positionQueryRepository)
        {
            _positionQueryRepository = positionQueryRepository;
        }

        public async Task<Paged<PositionBriefDto>> Handle(GetPositionQuery request, CancellationToken cancellationToken)
        {
            return await _positionQueryRepository.GetPagedByFilterAsync(request, cancellationToken);
        }
    }
}
