using Goldiran.Framework.Domain.Models;
using Mapster;
using MediatR;
using NgCrm.BasicInfoService.Domain.ADUsers.Contracts;
using NgCrm.BasicInfoService.Domain.ADUsers.Dtos;
using NgCrm.BasicInfoService.Domain.ADUsers.Queries;
using NgCrm.BasicInfoService.Domain.Users.Contracts;

namespace NgCrm.BasicInfoService.Application.ADUsers.Queries
{
    public class GetADUserQueryHandler : IRequestHandler<GetADUserQuery, Paged<ADUserBriefDto>>
    {
        private readonly IADUserQueryRepository _adUserQueryRepository;
        private readonly IUserQueryRepository _userQueryRepository;

        public GetADUserQueryHandler(IADUserQueryRepository adUserQueryRepository, IUserQueryRepository userQueryRepository)
        {
            _adUserQueryRepository = adUserQueryRepository;
            _userQueryRepository = userQueryRepository;
        }

        public async Task<Paged<ADUserBriefDto>> Handle(GetADUserQuery request, CancellationToken cancellationToken)
        {
            var adUsers = await _adUserQueryRepository.GetPagedByFilterAsync(request, cancellationToken);
            var list = adUsers.Items.Adapt<List<ADUserBriefDto>>();

            if (list.Any())
            {
                var adUserIds = list.Select(e => e.Id).ToList();
                var users = await _userQueryRepository.GetByIdsAsync(adUserIds, cancellationToken);

                var userDict = users.ToDictionary(u => u.ADUserId!.Value, u => u.PersonId);

                foreach (var item in list)
                {
                    if (userDict.TryGetValue(item.Id, out var personId))
                        item.PersonId = personId;                   
                }
            }

            return new Paged<ADUserBriefDto>(list, adUsers.PageNumber, adUsers.PageSize, adUsers.TotalCount);
        }
    }
}
