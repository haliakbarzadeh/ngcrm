using Goldiran.Framework.Domain.Models;
using Mapster;
using MediatR;
using NgCrm.BasicInfoService.Domain.AuditLogs.Contracts;
using NgCrm.BasicInfoService.Domain.AuditLogs.Dtos;
using NgCrm.BasicInfoService.Domain.AuditLogs.Queries;

namespace NgCrm.BasicInfoService.Application.AuditLogs.Queries
{
    public class GetAuditLogQueryHandler : IRequestHandler<GetAuditLogQuery, Paged<AuditLogDto>>
    {
        private readonly IAuditLogQueryRepository _AuditLogQueryRepository;

        public GetAuditLogQueryHandler(IAuditLogQueryRepository AuditLogQueryRepository)
        {
            _AuditLogQueryRepository = AuditLogQueryRepository;
        }

        public async Task<Paged<AuditLogDto>> Handle(GetAuditLogQuery request, CancellationToken cancellationToken)
        {
            var list = await _AuditLogQueryRepository.GetAuditLogs(request,cancellationToken);
            return list;
        }
    }
}
