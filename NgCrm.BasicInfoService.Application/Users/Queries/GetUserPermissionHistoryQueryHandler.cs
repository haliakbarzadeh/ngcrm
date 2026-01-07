using MediatR;
using NgCrm.BasicInfoService.Domain.Users.Contracts;
using NgCrm.BasicInfoService.Domain.Users.Queries;

namespace NgCrm.BasicInfoService.Application.Users.Queries
{
    public class GetUserPermissionHistoryQueryHandler : IRequestHandler<GetUserPermissionHistoryQuery, IEnumerable<long>>
    {
        private readonly IUserAuditService _userAuditService;

        public GetUserPermissionHistoryQueryHandler(IUserAuditService userAuditService)
        {
            _userAuditService = userAuditService;
        }

        public async Task<IEnumerable<long>> Handle(GetUserPermissionHistoryQuery request, CancellationToken cancellationToken)
        {
            return await _userAuditService.GetPermissions(request.UserId, request.TargetDate, cancellationToken);
        }
    }
}