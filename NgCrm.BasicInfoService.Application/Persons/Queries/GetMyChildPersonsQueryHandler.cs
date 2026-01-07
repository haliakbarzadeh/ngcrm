using Goldiran.Framework.Domain.Dtos;
using Goldiran.Framework.Domain.Exceptions;
using Goldiran.Framework.Domain.Services;
using MediatR;
using NgCrm.BasicInfoService.Domain.Persons.Contracts;
using NgCrm.BasicInfoService.Domain.Persons.Queries;

namespace NgCrm.BasicInfoService.Application.Persons.Queries
{
    public class GetMyChildPersonsQueryHandler : IRequestHandler<GetMyChildPersonsQuery, IEnumerable<SelectItemDto>>
    {
        private readonly IPersonQueryRepository _personQueryRepository;
        private readonly ICurrentUserService _currentUserService;

        public GetMyChildPersonsQueryHandler(
            IPersonQueryRepository personQueryRepository,
            ICurrentUserService currentUserService)
        {
            _personQueryRepository = personQueryRepository;
            _currentUserService = currentUserService;

        }

        public async Task<IEnumerable<SelectItemDto>> Handle(GetMyChildPersonsQuery request, CancellationToken cancellationToken)
        {
            var positionId = _currentUserService.PositionId;

            if (!positionId.HasValue)
            {
                throw new ValidationException("سمت کاربر مشخص نشده است");
            }

            // Get current user's position ID for hierarchy check

            return await _personQueryRepository.GetMyChildPersonsAsync(positionId.Value, cancellationToken);
        }
    }
}