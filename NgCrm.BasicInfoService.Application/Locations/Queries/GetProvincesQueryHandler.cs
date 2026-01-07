using Mapster;
using MediatR;
using NgCrm.BasicInfoService.Domain.Locations.Contracts;
using NgCrm.BasicInfoService.Domain.Locations.Dtos;
using NgCrm.BasicInfoService.Domain.Locations.Queries;

namespace NgCrm.BasicInfoService.Application.Locations.Queries
{
    public class GetProvincesQueryHandler : IRequestHandler<GetProvincesQuery, IList<LocationBriefDto>>
    {
        private readonly ILocationQueryRepository _locationQueryRepository;

        public GetProvincesQueryHandler(ILocationQueryRepository locationQueryRepository)
        {
            _locationQueryRepository = locationQueryRepository;
        }

        public async Task<IList<LocationBriefDto>> Handle(GetProvincesQuery request, CancellationToken cancellationToken)
        {
            var list = await _locationQueryRepository.GetProvincesAsync(cancellationToken);
            return list.Adapt<IList<LocationBriefDto>>();
        }
    }
}
