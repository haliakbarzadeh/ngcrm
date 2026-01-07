using MediatR;
using NgCrm.BasicInfoService.Domain.PersonDelegates.Dtos;

namespace NgCrm.BasicInfoService.Domain.PersonDelegates.Queries
{
    public class GetPersonDelegateByIdQuery : IRequest<PersonDelegateDto>
    {
        public long Id { get; set; }
    }


}