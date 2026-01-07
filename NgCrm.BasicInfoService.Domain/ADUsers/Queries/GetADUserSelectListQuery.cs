using Goldiran.Framework.Application.Queries;
using Goldiran.Framework.Domain.Dtos;
using MediatR;

namespace NgCrm.BasicInfoService.Domain.ADUsers.Queries
{
    public class GetADUserSelectListQuery : BaseQueryRequest, IRequest<IEnumerable<SelectItemDto>>
    {
        public string SearchTerm { get; set; }
        public int Take { get; set; } = 20;
    }
}
