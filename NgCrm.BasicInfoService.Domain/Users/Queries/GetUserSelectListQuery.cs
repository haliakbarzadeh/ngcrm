using Goldiran.Framework.Application.Queries;
using Goldiran.Framework.Domain.Dtos;
using MediatR;

namespace NgCrm.BasicInfoService.Domain.Users.Queries
{
    public class GetUserSelectListQuery : BaseQueryRequest, IRequest<IEnumerable<SelectItemDto>>
    {
        public string SearchTerm { get; set; }
    }
}
