using Goldiran.Framework.Domain.Models;
using Goldiran.Framework.Domain.Services;
using MediatR;
using NgCrm.BasicInfoService.Domain.AccessGroups.Contracts;
using NgCrm.BasicInfoService.Domain.AccessGroups.Dtos;
using NgCrm.BasicInfoService.Domain.AccessGroups.Queries;

namespace NgCrm.BasicInfoService.Application.AccessGroups.Queries
{
    public class GetAccessGroupQueryHandler : IRequestHandler<GetAccessGroupQuery, Paged<AccessGroupBriefDto>>
    {
        private readonly IAccessGroupQueryRepository _accessGroupQueryRepository;
        private readonly ICurrentUserService _currentUserService;

        public GetAccessGroupQueryHandler(IAccessGroupQueryRepository accessGroupQueryRepository, ICurrentUserService currentUserService)
        {
            _accessGroupQueryRepository = accessGroupQueryRepository;
            _currentUserService = currentUserService;
        }

        public async Task<Paged<AccessGroupBriefDto>> Handle(GetAccessGroupQuery request, CancellationToken cancellationToken)
        {
            // sample by babak
            //var user = _currentUserService.CurrentUser;

            var result = await _accessGroupQueryRepository.GetPagedByFilterAsync(request, cancellationToken);

            return result;
        }
    }
}
