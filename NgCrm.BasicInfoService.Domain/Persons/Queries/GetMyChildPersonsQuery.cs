using Goldiran.Framework.Application.Queries;
using Goldiran.Framework.Domain.Dtos;
using MediatR;

namespace NgCrm.BasicInfoService.Domain.Persons.Queries
{
    public class GetMyChildPersonsQuery : BaseQueryRequest, IRequest<IEnumerable<SelectItemDto>>
    {
        // No additional properties needed since we'll get the current user context from the handler
    }
}