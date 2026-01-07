using Mapster;
using MediatR;
using NgCrm.BasicInfoService.Domain.Locations.Contracts;
using NgCrm.BasicInfoService.Domain.Locations.Dtos;
using NgCrm.BasicInfoService.Domain.Locations.Queries;
using NgCrm.BasicInfoService.Domain.Locations.ReadModels;

namespace NgCrm.BasicInfoService.Application.Locations.Queries
{
    public class GetCitiesQueryHandler : IRequestHandler<GetCitiesQuery, IList<LocationBriefDto>>
    {
        private readonly ILocationQueryRepository _locationQueryRepository;

        public GetCitiesQueryHandler(ILocationQueryRepository locationQueryRepository)
        {
            _locationQueryRepository = locationQueryRepository;
        }

        public async Task<IList<LocationBriefDto>> Handle(GetCitiesQuery request, CancellationToken cancellationToken)
        {
            var list = await _locationQueryRepository.GetCitiesAsync(request.ProvinceId, cancellationToken);
            return list.Adapt<IList<LocationBriefDto>>();
        }
    }
}
