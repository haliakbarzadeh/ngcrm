using Goldiran.Framework.Domain.Dtos;
using MediatR;
using NgCrm.BasicInfoService.Domain.ADUsers.Contracts;
using NgCrm.BasicInfoService.Domain.ADUsers.Queries;

namespace NgCrm.BasicInfoService.Application.ADUsers.Queries
{
    public class GetADUserSelectListQueryHandler : IRequestHandler<GetADUserSelectListQuery, IEnumerable<SelectItemDto>>
    {
        private readonly IADUserQueryRepository _aDUserQueryRepository;

        public GetADUserSelectListQueryHandler(IADUserQueryRepository aDUserQueryRepository)
        {
            _aDUserQueryRepository = aDUserQueryRepository;
        }

        public async Task<IEnumerable<SelectItemDto>> Handle(GetADUserSelectListQuery request, CancellationToken cancellationToken)
        {
            var list = await _aDUserQueryRepository.GetADUserSelectListAsync(request, cancellationToken);
            return list;
        }
    }
}
