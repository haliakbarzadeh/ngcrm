using Goldiran.Framework.AspNetCore;
using Goldiran.Framework.Domain.Dtos;
using Goldiran.Framework.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NgCrm.BasicInfoService.Application.Positions.Commands;
using NgCrm.BasicInfoService.Domain.Positions.Dtos;
using NgCrm.BasicInfoService.Domain.Positions.Queries;

namespace NgCrm.BasicInfoService.Api.Controllers
{
    [ApiController]
    [Route("api/v1/position")]
    public class PositionController : GoldiranController<PositionController>
    {
        public PositionController(ISender sender, ILogger<PositionController> logger) : base(sender, logger)
        {

        }

        [HttpPost("create")]
        public async Task<ActionResult<bool>> Create([FromBody] CreatePositionCommand request, CancellationToken cancellationToken)
        {
            return await Sender.Send(request, cancellationToken);
        }

        [HttpPost("get")]
        public async Task<ActionResult<Paged<PositionBriefDto>>> Get([FromBody] GetPositionQuery request, CancellationToken cancellationToken)
        {
            return await Sender.Send(request, cancellationToken);
        }

        [HttpGet("get-by-id")]
        public async Task<ActionResult<PositionDto>> GetById(int id, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(new GetPositionByIdQuery() { Id = id }, cancellationToken);

            return result;
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<bool>> Delete([FromQuery] DeletePositionCommand request, CancellationToken cancellationToken)
        {
            return await Sender.Send(request, cancellationToken);
        }

        [HttpPut("update")]
        public async Task<ActionResult<bool>> Update([FromBody] UpdatePositionCommand request, CancellationToken cancellationToken)
        {
            return await Sender.Send(request, cancellationToken);
        }

        [HttpPut("set-permission-to-position")]
        public async Task<ActionResult<bool>> SetPermissionsToPosition([FromBody] SetPermissionsToPositionCommand request, CancellationToken cancellationToken)
        {
            return await Sender.Send(request, cancellationToken);
        }

        [HttpPatch("change-position-activation")]
        public async Task<ActionResult<bool>> ChangePositionActivation([FromBody] ToggleIsActivePositionCommand request, CancellationToken cancellationToken)
        {
            return await Sender.Send(request, cancellationToken);
        }

        [HttpGet("get-positions-by-organizationid-selectlist")]
        public async Task<ActionResult<IEnumerable<SelectItemDto>>> GetPositionsByOrganizationIdSelectList(int organizationId, CancellationToken cancellationToken)
        {
            return (await Sender.Send(new GetPositionsByOrganizationIdSelectListQuery() { OrganizationId = organizationId }, cancellationToken)).ToList();

        }

        [HttpGet("get-positions-selectlist")]
        public async Task<ActionResult<IEnumerable<SelectItemDto>>> GetPositionsSelectList(CancellationToken cancellationToken)
        {
            return (await Sender.Send(new GetPositionsSelectListQuery(), cancellationToken)).ToList();

        }

        [HttpPost("get-by-personid")]
        public async Task<ActionResult<Paged<PositionBriefDto>>> GetByPersonId([FromBody] GetPositionByPersonIdQuery request, CancellationToken cancellationToken)
        {
            return await Sender.Send(request, cancellationToken);
        }

        [HttpGet("permission-history")]
        public async Task<ActionResult<IEnumerable<long>>> GetPermissionHistory([FromQuery] GetPositionPermissionHistoryQuery request, CancellationToken cancellationToken)
        {
            return (await Sender.Send(request, cancellationToken)).ToList();
        }
    }
}
