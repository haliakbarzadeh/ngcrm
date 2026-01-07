using Goldiran.Framework.Application.Queries;
using MediatR;
using NgCrm.BasicInfoService.Domain.Locations.Dtos;

namespace NgCrm.BasicInfoService.Domain.Locations.Queries
{
    public class GetCitiesQuery : BaseQueryRequest, IRequest<IList<LocationBriefDto>>
    {
        public long ProvinceId { get; set; }
    }
}
