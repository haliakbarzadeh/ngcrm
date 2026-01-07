using Goldiran.Framework.Application.Queries;
using MediatR;
using NgCrm.BasicInfoService.Domain.Persons.Dtos;

namespace NgCrm.BasicInfoService.Domain.Persons.Queries
{
    public class GetPermissionsByPersonIdQuery : BaseQueryRequest, IRequest<IEnumerable<PersonPermissionDto>>
    {
        public long PersonId { get; set; }
        public long? PositionId { get; set; }
    }
}
