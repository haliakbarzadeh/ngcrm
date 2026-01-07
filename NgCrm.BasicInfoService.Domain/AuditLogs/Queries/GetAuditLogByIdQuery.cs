using Goldiran.Framework.Application.Queries;
using MediatR;
using NgCrm.BasicInfoService.Domain.AuditLogs.Dtos;

namespace NgCrm.BasicInfoService.Domain.AuditLogs.Queries
{
    public class GetAuditLogByIdQuery : BaseQueryRequest, IRequest<AuditLogDetailsDto>
    {
        public long Id { get; set; }
    }

}
