using Goldiran.Framework.Application.Queries;
using MediatR;
using NgCrm.BasicInfoService.Domain.Persons.Dtos;

namespace NgCrm.BasicInfoService.Domain.Persons.Queries
{
    public class GetPersonByNationalCodeQuery : BaseQueryRequest, IRequest<PersonDto>
    {
        public string NationalCode { get; set; }
    }
}
