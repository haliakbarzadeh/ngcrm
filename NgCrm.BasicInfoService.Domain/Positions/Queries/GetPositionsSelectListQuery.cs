using Goldiran.Framework.Application.Queries;
using Goldiran.Framework.Domain.Dtos;
using MediatR;

namespace NgCrm.BasicInfoService.Domain.Positions.Queries
{
    public class GetPositionsSelectListQuery : BaseQueryRequest, IRequest<IEnumerable<SelectItemDto>>
    {
    }

}
