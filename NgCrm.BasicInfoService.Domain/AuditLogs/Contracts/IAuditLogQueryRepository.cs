using Goldiran.Framework.Domain.Contracts;
using Goldiran.Framework.Domain.Models;
using NgCrm.BasicInfoService.Domain.BaseInfos.Dtos;
using NgCrm.BasicInfoService.Domain.BaseInfos.Queries;
using NgCrm.BasicInfoService.Domain.AuditLogs.Dtos;
using NgCrm.BasicInfoService.Domain.AuditLogs.Queries;

namespace NgCrm.BasicInfoService.Domain.AuditLogs.Contracts
{
    public interface IAuditLogQueryRepository
    {
        public Task<Paged<AuditLogDto>> GetAuditLogs(GetAuditLogQuery filter, CancellationToken cancellationToken);
        public Task<AuditLogDetailsDto> GetByIdAsync(long id);
    }
}
