using Goldiran.Framework.Domain.Dtos;
using MediatR;
using NgCrm.BasicInfoService.Domain.Persons.Contracts;
using NgCrm.BasicInfoService.Domain.Persons.Dtos;
using NgCrm.BasicInfoService.Domain.Persons.Queries;

namespace NgCrm.BasicInfoService.Application.Persons.Queries
{
    public class GetPersonSummaryQueryHandler : IRequestHandler<GetPersonSummaryQuery, IEnumerable<PersonSummaryDto>>
    {
        private readonly IPersonQueryRepository _personQueryRepository;

        public GetPersonSummaryQueryHandler(IPersonQueryRepository personQueryRepository)
        {
            _personQueryRepository = personQueryRepository;
        }

        public async Task<IEnumerable<PersonSummaryDto>> Handle(GetPersonSummaryQuery request, CancellationToken cancellationToken)
        {
            var list = await _personQueryRepository.GetGetPersonSummaryAsync(request, cancellationToken);
            return list;
        }
    }
}
