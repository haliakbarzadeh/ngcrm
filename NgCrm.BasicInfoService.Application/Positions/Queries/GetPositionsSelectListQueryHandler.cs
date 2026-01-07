using Goldiran.Framework.Domain.Dtos;
using MediatR;
using NgCrm.BasicInfoService.Domain.Positions.Contracts;
using NgCrm.BasicInfoService.Domain.Positions.Queries;

namespace NgCrm.BasicInfoService.Application.Positions.Queries
{
    public class GetPositionsSelectListQueryHandler : IRequestHandler<GetPositionsSelectListQuery, IEnumerable<SelectItemDto>>
    {
        private readonly IPositionQueryRepository _positionQueryRepository;

        public GetPositionsSelectListQueryHandler(IPositionQueryRepository positionQueryRepository)
        {
            _positionQueryRepository = positionQueryRepository;
        }

        public async Task<IEnumerable<SelectItemDto>> Handle(GetPositionsSelectListQuery request, CancellationToken cancellationToken)
        {
            var list = await _positionQueryRepository.GetPositionsSelectListAsync(cancellationToken);
            return list;
        }
    }
}
