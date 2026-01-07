using Goldiran.Framework.Application.Queries;
using Goldiran.Framework.Domain.Dtos;
using MediatR;

namespace NgCrm.BasicInfoService.Domain.Persons.Queries
{
    public class GetPersonPositionsQuery : BaseQueryRequest, IRequest<IEnumerable<SelectItemDto>>
    {
        public long PersonId { get; set; }
    }
}