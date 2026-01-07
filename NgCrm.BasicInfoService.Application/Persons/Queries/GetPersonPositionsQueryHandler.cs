using Goldiran.Framework.Domain.Dtos;
using Goldiran.Framework.Domain.Services;
using MediatR;
using NgCrm.BasicInfoService.Domain.Persons.Contracts;
using NgCrm.BasicInfoService.Domain.Persons.Queries;

namespace NgCrm.BasicInfoService.Application.Persons.Queries
{
    public class GetPersonPositionsQueryHandler : IRequestHandler<GetPersonPositionsQuery, IEnumerable<SelectItemDto>>
    {
        private readonly IPersonQueryRepository _personQueryRepository;
        private readonly ICurrentUserService _currentUserService;

        public GetPersonPositionsQueryHandler(IPersonQueryRepository personQueryRepository, ICurrentUserService currentUserService)
        {
            _personQueryRepository = personQueryRepository;
            _currentUserService = currentUserService;
        }

        public async Task<IEnumerable<SelectItemDto>> Handle(GetPersonPositionsQuery request, CancellationToken cancellationToken)
        {
            var positions = await _personQueryRepository.GetPositionsByPersonIdAsync(request.PersonId, cancellationToken);
            return positions;
        }
    }
}