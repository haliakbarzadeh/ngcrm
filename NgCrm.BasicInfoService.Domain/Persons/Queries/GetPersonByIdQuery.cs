using Goldiran.Framework.Application.Queries;
using MediatR;
using NgCrm.BasicInfoService.Domain.Persons.Dtos;

namespace NgCrm.BasicInfoService.Domain.Persons.Queries
{
    public class GetPersonByIdQuery : BaseQueryRequest, IRequest<PersonDto>
    {
        public long Id { get; set; }
    }
}
