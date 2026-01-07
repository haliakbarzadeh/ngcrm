using Goldiran.Framework.Application.Queries;
using MediatR;
using NgCrm.BasicInfoService.Domain.Locations.Dtos;
using NgCrm.BasicInfoService.Domain.Locations.ReadModels;

namespace NgCrm.BasicInfoService.Domain.Locations.Queries
{
    public class GetProvincesQuery : BaseQueryRequest, IRequest<IList<LocationBriefDto>>
    {

    }
}
