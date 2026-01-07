using Goldiran.Framework.Application.Queries;
using MediatR;
using NgCrm.BasicInfoService.Domain.PersonAccessGroups.Dtos;

namespace NgCrm.BasicInfoService.Domain.PersonAccessGroups.Queries
{
    public class GetPersonAccessGroupQuery : BaseQueryRequest, IRequest<IEnumerable<PersonAccessGroupBriefDto>>
    {
    }
}
