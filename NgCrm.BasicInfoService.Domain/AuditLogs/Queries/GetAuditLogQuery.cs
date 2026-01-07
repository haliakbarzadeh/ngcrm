using Goldiran.Framework.Application.Queries;
using Goldiran.Framework.Domain.Models;
using MediatR;
using NgCrm.BasicInfoService.Domain.AuditLogs.Dtos;
using NgCrm.BasicInfoService.Domain.Common.Enums;
using NgCrm.BasicInfoService.Domain.AuditLogs.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Goldiran.Framework.Domain.Enums;

namespace NgCrm.BasicInfoService.Domain.AuditLogs.Queries
{
    public class GetAuditLogQuery : BaseQueryRequest, IRequest<Paged<AuditLogDto>>
    {
        public AuditLogType? EntityName { get; set; }
        public ChangeTypes? ChangeType { get; set; }
        public long? EntityId { get; set; }
        public long? UserId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

    }
}
