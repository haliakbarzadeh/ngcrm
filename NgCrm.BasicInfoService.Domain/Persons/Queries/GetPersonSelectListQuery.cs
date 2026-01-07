using Goldiran.Framework.Application.Queries;
using Goldiran.Framework.Domain.Dtos;
using MediatR;

namespace NgCrm.BasicInfoService.Domain.Persons.Queries
{
    public class GetPersonSelectListQuery : BaseQueryRequest, IRequest<IEnumerable<SelectItemDto>>
    {
        public string SearchTerm { get; set; }
        public int Take { get; set; } = 20;
    }
}
