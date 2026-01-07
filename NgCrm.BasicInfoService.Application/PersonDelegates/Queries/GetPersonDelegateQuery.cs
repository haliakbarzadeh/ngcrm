using Goldiran.Framework.Domain.Models;
using Mapster;
using MediatR;
using NgCrm.BasicInfoService.Domain.PersonDelegates.Contracts;
using NgCrm.BasicInfoService.Domain.PersonDelegates.Dtos;
using NgCrm.BasicInfoService.Domain.PersonDelegates.Queries;

namespace NgCrm.BasicInfoService.Application.PersonDelegates.Queries
{
    public class GetPersonDelegateQueryHandler : IRequestHandler<GetPersonDelegateQuery, Paged<PersonDelegateBriefDto>>
    {
        private readonly IPersonDelegateQueryRepository _personDelegateRepository;

        public GetPersonDelegateQueryHandler(IPersonDelegateQueryRepository personDelegateRepository)
        {
            _personDelegateRepository = personDelegateRepository;
        }

        public async Task<Paged<PersonDelegateBriefDto>> Handle(GetPersonDelegateQuery request, CancellationToken cancellationToken)
        {
            var result = await _personDelegateRepository.GetPagedByFilterAsync(request, cancellationToken);
            return result.Adapt<Paged<PersonDelegateBriefDto>>();
        }
    }
}