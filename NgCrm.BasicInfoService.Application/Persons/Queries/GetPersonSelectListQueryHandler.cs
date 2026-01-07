using Goldiran.Framework.Domain.Dtos;
using MediatR;
using NgCrm.BasicInfoService.Domain.Persons.Contracts;
using NgCrm.BasicInfoService.Domain.Persons.Queries;

namespace NgCrm.BasicInfoService.Application.Persons.Queries
{
    public class GetPersonSelectListQueryHandler : IRequestHandler<GetPersonSelectListQuery, IEnumerable<SelectItemDto>>
    {
        private readonly IPersonQueryRepository _personQueryRepository;

        public GetPersonSelectListQueryHandler(IPersonQueryRepository personQueryRepository)
        {
            _personQueryRepository = personQueryRepository;
        }

        public async Task<IEnumerable<SelectItemDto>> Handle(GetPersonSelectListQuery request, CancellationToken cancellationToken)
        {
            var list = await _personQueryRepository.GetPersonSelectListAsync(request, cancellationToken);
            return list;
        }
    }
}
