using Goldiran.Framework.Application.Queries;
using MediatR;
using NgCrm.BasicInfoService.Domain.Locations.ReadModels;

namespace NgCrm.BasicInfoService.Domain.Locations.Queries
{
    public class GetRegionsQuery : BaseQueryRequest, IRequest<IList<LocationReadModel>>
    {
        public long CityId { get; set; }
    }
}
