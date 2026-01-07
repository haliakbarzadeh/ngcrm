using Goldiran.Framework.Domain.Dtos;
using MediatR;
using NgCrm.BasicInfoService.Domain.AccessGroups.Contracts;
using NgCrm.BasicInfoService.Domain.Positions.Contracts;
using NgCrm.BasicInfoService.Domain.Positions.Queries;

namespace NgCrm.BasicInfoService.Application.Positions.Queries
{
    public class GetAccessGroupsSelectListQueryHandler : IRequestHandler<GetAccessGroupsSelectListQuery, IEnumerable<SelectItemDto>>
    {
        private readonly IAccessGroupQueryRepository _accessGroupQueryRepository;

        public GetAccessGroupsSelectListQueryHandler(IAccessGroupQueryRepository accessGroupQueryRepository)
        {
            _accessGroupQueryRepository = accessGroupQueryRepository;
        }

        public async Task<IEnumerable<SelectItemDto>> Handle(GetAccessGroupsSelectListQuery request, CancellationToken cancellationToken)
        {
            var list = await _accessGroupQueryRepository.GetAccessGroupsSelectListAsync(request, cancellationToken);
            return list;
        }
    }
}
