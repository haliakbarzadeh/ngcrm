                  using Goldiran.Framework.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NgCrm.BasicInfoService.Domain.Permissions.Dtos;
using NgCrm.BasicInfoService.Domain.Permissions.Queries;
using NgCrm.BasicInfoService.Domain.Permissions.ReadModels;

namespace NgCrm.BasicInfoService.Api.Controllers
{
    [ApiController]
    [Route("api/v1/permission")]
    public class PermissionController : GoldiranController<PermissionController>
    {
        public PermissionController(ISender sender, ILogger<PermissionController> logger) : base(sender, logger)
        {

        }


        [HttpGet("get")]
        public async Task<ActionResult<IEnumerable<PermissionBriefDto>>> Get([FromQuery] GetPermissionQuery request, CancellationToken cancellationToken)
        {
            var list = await Sender.Send(request, cancellationToken);

            return list.ToList();
        }


        [HttpGet("get-all-by-workspace-id")]
        public async Task<ActionResult<IEnumerable<PermissionBriefDto>>> GetAllByWorkspaceId([FromQuery] GetPermissionByWorkspaceIdQuery request, CancellationToken cancellationToken)
        {
            var list = await Sender.Send(request, cancellationToken);

            return list.ToList();
        }

        [HttpGet("get-all-by-position-id")]
        public async Task<ActionResult<IEnumerable<PermissionBriefDto>>> GetAllByPositionId([FromQuery] GetPermissionByWorkspaceIdQuery request, CancellationToken cancellationToken)
        {
            var list = await Sender.Send(request, cancellationToken);

            return list.ToList();
        }

        [HttpGet("get-permissionlite-by-workspaceid")]
        public async Task<ActionResult<IEnumerable<PermissionLiteDto>>> GetPermissionLiteByWorkspaceId(long id, CancellationToken cancellationToken)
        {
            return (await Sender.Send(new GetPermissionLiteByWorkspaceIdQuery { WorkspaceId = id }, cancellationToken)).ToList();
        }

        [HttpGet("get-permissionlite-by-positionid")]
        public async Task<ActionResult<IEnumerable<PermissionLiteDto>>> GetPermissionLiteByPositionId(long id, CancellationToken cancellationToken)
        {
            return (await Sender.Send(new GetPermissionLiteByPositionIdQuery { PositionId = id }, cancellationToken)).ToList();
        }
    }
}
