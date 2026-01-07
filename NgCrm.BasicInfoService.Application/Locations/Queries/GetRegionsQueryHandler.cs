using MediatR;
using NgCrm.BasicInfoService.Domain.Locations.Contracts;
using NgCrm.BasicInfoService.Domain.Locations.Queries;
using NgCrm.BasicInfoService.Domain.Locations.ReadModels;

namespace NgCrm.BasicInfoService.Application.Locations.Queries
{
    public class GetRegionsQueryHandler : IRequestHandler<GetRegionsQuery, IList<LocationReadModel>>
    {
        private readonly ILocationQueryRepository _locationQueryRepository;

        public GetRegionsQueryHandler(ILocationQueryRepository locationQueryRepository)
        {
            _locationQueryRepository = locationQueryRepository;
        }

        public async Task<IList<LocationReadModel>> Handle(GetRegionsQuery request, CancellationToken cancellationToken)
        {
            return await _locationQueryRepository.GetRegionsAsync(request.CityId, cancellationToken);
        }
    }
}
