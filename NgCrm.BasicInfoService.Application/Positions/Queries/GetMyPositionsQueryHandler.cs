using Goldiran.Framework.Domain.Dtos;
using Goldiran.Framework.Domain.Services;
using MediatR;
using NgCrm.BasicInfoService.Domain.Positions.Queries;
using NgCrm.BasicInfoService.Domain.Users.Contracts;

namespace NgCrm.BasicInfoService.Application.Positions.Queries
{
    public class GetMyPositionsQueryHandler : IRequestHandler<GetMyPositionsQuery, IEnumerable<SelectItemDto>>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IUserQueryRepository _userQueryRepository;

        public GetMyPositionsQueryHandler(ICurrentUserService currentUserService, IUserQueryRepository userQueryRepository)
        {
            _currentUserService = currentUserService;
            _userQueryRepository = userQueryRepository;
        }

        public async Task<IEnumerable<SelectItemDto>> Handle(GetMyPositionsQuery request, CancellationToken cancellationToken)
        {
            return await _userQueryRepository.GetPositionsByUserIdAsync((long)_currentUserService.UserId, cancellationToken);
        }
    }
}
