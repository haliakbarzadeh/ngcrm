using Goldiran.Framework.Domain.Models;
using Mapster;
using MediatR;
using NgCrm.BasicInfoService.Domain.Persons.Contracts;
using NgCrm.BasicInfoService.Domain.Persons.Dtos;
using NgCrm.BasicInfoService.Domain.Persons.Queries;

namespace NgCrm.BasicInfoService.Application.Persons.Queries
{
    public class GetPersonQueryHandler : IRequestHandler<GetPersonQuery, Paged<PersonBriefDto>>
    {
        private readonly IPersonQueryRepository _personQueryRepository;

        public GetPersonQueryHandler(IPersonQueryRepository personQueryRepository)
        {
            _personQueryRepository = personQueryRepository;
        }

        public async Task<Paged<PersonBriefDto>> Handle(GetPersonQuery request, CancellationToken cancellationToken)
        {
            var list = await _personQueryRepository.GetPagedByFilterAsync(request,  cancellationToken);
            return list.Adapt<Paged<PersonBriefDto>>();
        }
    }
}
