using MediatR;
using NgCrm.BasicInfoService.Domain.Positions.Contracts;
using NgCrm.BasicInfoService.Domain.Positions.Queries;

namespace NgCrm.BasicInfoService.Application.Positions.Queries
{
    public class GetPositionPermissionHistoryQueryHandler : IRequestHandler<GetPositionPermissionHistoryQuery, IEnumerable<long>>
    {
        private readonly IPositionAuditService _positionAuditService;

        public GetPositionPermissionHistoryQueryHandler(IPositionAuditService positionAuditService)
        {
            _positionAuditService = positionAuditService;
        }

        public async Task<IEnumerable<long>> Handle(GetPositionPermissionHistoryQuery request, CancellationToken cancellationToken)
        {
            return await _positionAuditService.GetPermissionHistory(request.PositionId, request.TargetDate, cancellationToken);
        }
    }
}