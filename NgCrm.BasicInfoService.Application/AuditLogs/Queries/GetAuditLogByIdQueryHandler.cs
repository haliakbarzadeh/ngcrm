using Mapster;
using MediatR;
using NgCrm.BasicInfoService.Domain.AuditLogs.Contracts;
using NgCrm.BasicInfoService.Domain.AuditLogs.Dtos;
using NgCrm.BasicInfoService.Domain.AuditLogs.Queries;
using NgCrm.BasicInfoService.Domain.Positions.Contracts;
using NgCrm.BasicInfoService.Domain.Positions.Dtos;

namespace NgCrm.BasicInfoService.Application.AuditLogs.Queries
{
    public class GetAuditLogByIdQueryHandler : IRequestHandler<GetAuditLogByIdQuery, AuditLogDetailsDto>
    {
        private readonly IAuditLogQueryRepository _AuditLogQueryRepository;

        public GetAuditLogByIdQueryHandler(IAuditLogQueryRepository AuditLogQueryRepository)
        {
            _AuditLogQueryRepository = AuditLogQueryRepository;
        }

        public async Task<AuditLogDetailsDto> Handle(GetAuditLogByIdQuery request, CancellationToken cancellationToken)
        {
            var AuditLog = await _AuditLogQueryRepository.GetByIdAsync(request.Id);

            if (AuditLog is null)
                throw new KeyNotFoundException("شخص مورد نظر یافت نشد.");

            return AuditLog;
        }
    }
}
