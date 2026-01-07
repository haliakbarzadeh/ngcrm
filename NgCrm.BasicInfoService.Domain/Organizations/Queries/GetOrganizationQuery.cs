using Goldiran.Framework.Application.Queries;
using MediatR;
using NgCrm.BasicInfoService.Domain.Organizations.Dtos;

namespace NgCrm.BasicInfoService.Domain.Organizations.Queries
{
    public class GetOrganizationQuery : BaseQueryRequest, IRequest<IEnumerable<OrganizationBriefDto>>
    {
        //public string Firsname { get; set; }
    }
}
