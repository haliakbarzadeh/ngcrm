using Goldiran.Framework.Domain.Models;
using Mapster;
using MediatR;
using NgCrm.BasicInfoService.Domain.Users.Contracts;
using NgCrm.BasicInfoService.Domain.Users.Dtos;
using NgCrm.BasicInfoService.Domain.Users.Queries;

namespace NgCrm.BasicInfoService.Application.Users.Queries
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, Paged<UserBriefDto>>
    {
        private readonly IUserQueryRepository _userQueryRepository;

        public GetUserQueryHandler(IUserQueryRepository userQueryRepository)
        {
            _userQueryRepository = userQueryRepository;
        }

        public async Task<Paged<UserBriefDto>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var userBriefDtos = await _userQueryRepository.GetPagedByFilterAsync(request, cancellationToken);
            return userBriefDtos;
        }
    }
}
