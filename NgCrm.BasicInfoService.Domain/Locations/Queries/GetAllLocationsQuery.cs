using Goldiran.Framework.Application.Queries;
using MediatR;
using NgCrm.BasicInfoService.Domain.Locations.Dtos;
using NgCrm.BasicInfoService.Domain.Locations.ReadModels;

namespace NgCrm.BasicInfoService.Domain.Locations.Queries
{
    public class GetAllLocationsQuery : BaseQueryRequest, IRequest<IList<LocationBriefDto>>
    {

    }
}
