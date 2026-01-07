using Goldiran.Framework.Domain.Dtos;
using MediatR;
using NgCrm.BasicInfoService.Domain.Users.Contracts;
using NgCrm.BasicInfoService.Domain.Users.Queries;

namespace NgCrm.BasicInfoService.Application.Users.Queries
{
    public class GetUserSelectListQueryHandler : IRequestHandler<GetUserSelectListQuery, IEnumerable<SelectItemDto>>
    {
        private readonly IUserQueryRepository _userQueryRepository;

        public GetUserSelectListQueryHandler(IUserQueryRepository userQueryRepository)
        {
            _userQueryRepository = userQueryRepository;
        }

        public async Task<IEnumerable<SelectItemDto>> Handle(GetUserSelectListQuery request, CancellationToken cancellationToken)
        {
            var users = await _userQueryRepository.GetUserSelectList(request, cancellationToken);
            return users;
        }
    }
}
