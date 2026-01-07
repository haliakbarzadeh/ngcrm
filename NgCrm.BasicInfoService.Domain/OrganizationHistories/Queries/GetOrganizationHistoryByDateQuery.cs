using Goldiran.Framework.Application.Queries;
using MediatR;
using NgCrm.BasicInfoService.Domain.OrganizationHistories.Dtos;
using NgCrm.BasicInfoService.Domain.Organizations.Dtos;

namespace NgCrm.BasicInfoService.Domain.OrganizationHistories.Queries
{
    public class GetOrganizationHistoryByDateQuery : BaseQueryRequest, IRequest<OrganizationHistoryDto>
    {
        public DateTime FromDate { get; set; }
    }
}
