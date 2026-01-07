using Goldiran.Framework.Application.Queries;
using MediatR;
using NgCrm.BasicInfoService.Domain.Organizations.Dtos;

namespace NgCrm.BasicInfoService.Domain.Organizations.Queries
{
    public class GetOrganizationByIdQuery : BaseQueryRequest, IRequest<OrganizationDto>
    {
        public long Id { get; set; }
    }
}
