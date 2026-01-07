using Goldiran.Framework.Application.Queries;
using MediatR;
using NgCrm.BasicInfoService.Domain.Persons.Dtos;

namespace NgCrm.BasicInfoService.Domain.Persons.Queries
{
    public class GetPersonByPersonalCodeQuery : BaseQueryRequest, IRequest<PersonDto>
    {
        public string PersonalCode { get; set; }
    }
}
