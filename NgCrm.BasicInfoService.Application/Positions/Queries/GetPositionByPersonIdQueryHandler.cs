using Goldiran.Framework.Domain.Models;
using MediatR;
using NgCrm.BasicInfoService.Domain.Positions.Contracts;
using NgCrm.BasicInfoService.Domain.Positions.Dtos;
using NgCrm.BasicInfoService.Domain.Positions.Queries;

namespace NgCrm.BasicInfoService.Application.Positions.Queries
{
    public class GetPositionByPersonIdQueryHandler : IRequestHandler<GetPositionByPersonIdQuery, Paged<PositionBriefDto>>
    {
        private readonly IPositionQueryRepository _positionQueryRepository;

        public GetPositionByPersonIdQueryHandler(IPositionQueryRepository positionQueryRepository)
        {
            _positionQueryRepository = positionQueryRepository;
        }

        public async Task<Paged<PositionBriefDto>> Handle(GetPositionByPersonIdQuery request, CancellationToken cancellationToken)
        {
            if (request is null || request?.PersonId == 0)
                throw new KeyNotFoundException("لطفا شناسه کاربر را وارد کنید.");

            return await _positionQueryRepository.GetByPersonIdPagedByFilterAsync(request, cancellationToken);
        }
    }
}
