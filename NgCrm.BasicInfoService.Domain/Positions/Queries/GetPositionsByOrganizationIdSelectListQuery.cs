using Goldiran.Framework.Application.Queries;
using Goldiran.Framework.Domain.Dtos;
using MediatR;

namespace NgCrm.BasicInfoService.Domain.Positions.Queries
{
    public class GetPositionsByOrganizationIdSelectListQuery : BaseQueryRequest, IRequest<IEnumerable<SelectItemDto>>
    {
        public long OrganizationId { get; set; }
    }

}
