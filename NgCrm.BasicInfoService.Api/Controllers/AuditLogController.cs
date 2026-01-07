using Goldiran.Framework.AspNetCore;
using Goldiran.Framework.Domain.Extensions;
using Goldiran.Framework.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using NgCrm.BasicInfoService.Domain.Common.Attributes;
using NgCrm.BasicInfoService.Domain.AuditLogs.Dtos;
using NgCrm.BasicInfoService.Domain.AuditLogs.Queries;
using System.Reflection;
using System.Text.Json.Nodes;

namespace NgCrm.BasicInfoService.Api.Controllers
{
    [ApiController]
    [Route("api/v1/auditlog")]
    public class AuditLogController : GoldiranController<AuditLogController>
    {
        public AuditLogController(ISender sender, ILogger<AuditLogController> logger) : base(sender, logger)
        {

        }


        [HttpGet("get")]
        public async Task<ActionResult<Paged<AuditLogDto>>> Get([FromQuery] GetAuditLogQuery request, CancellationToken cancellationToken)
        {
            return await Sender.Send(request, cancellationToken);
        }

        [HttpGet("get-by-id")]
        public async Task<ActionResult<AuditLogDetailsDto>> GetById(long id, CancellationToken cancellationToken)
        {
            var t = await Sender.Send(new GetAuditLogByIdQuery { Id = id }, cancellationToken);
            return await Sender.Send(new GetAuditLogByIdQuery { Id = id }, cancellationToken);
        }

    }
}
