using Mapster;
using MediatR;
using NgCrm.BasicInfoService.Domain.Locations.Contracts;
using NgCrm.BasicInfoService.Domain.Locations.Dtos;
using NgCrm.BasicInfoService.Domain.Locations.Queries;
using NgCrm.BasicInfoService.Domain.Locations.ReadModels;

namespace NgCrm.BasicInfoService.Application.Locations.Queries
{
    public class GetAllLocationsQueryHandler : IRequestHandler<GetAllLocationsQuery, IList<LocationBriefDto>>
    {
        private readonly ILocationQueryRepository _locationQueryRepository;

        public GetAllLocationsQueryHandler(ILocationQueryRepository locationQueryRepository)
        {
            _locationQueryRepository = locationQueryRepository;
        }

        public async Task<IList<LocationBriefDto>> Handle(GetAllLocationsQuery request, CancellationToken cancellationToken)
        {
            var list = await _locationQueryRepository.GetAllAsync(cancellationToken);
            return list.Adapt<IList<LocationBriefDto>>();
        }
    }
}
