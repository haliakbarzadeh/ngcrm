using Goldiran.Framework.Application.Queries;
using MediatR;
using NgCrm.BasicInfoService.Domain.Persons.Dtos;

namespace NgCrm.BasicInfoService.Domain.Persons.Queries
{
    public class GetPersonSummaryQuery : BaseQueryRequest, IRequest<IEnumerable<PersonSummaryDto>>
    {
        public string SearchTerm { get; set; }
        public int Take { get; set; } = 20;
    }
}
