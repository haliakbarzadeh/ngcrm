using Goldiran.Framework.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NgCrm.BasicInfoService.Application.Workspaces.Commands;
using NgCrm.BasicInfoService.Domain.Permissions.Dtos;
using NgCrm.BasicInfoService.Domain.Permissions.Queries;
using NgCrm.BasicInfoService.Domain.Workspaces.Dtos;
using NgCrm.BasicInfoService.Domain.Workspaces.Queries;
using NgCrm.BasicInfoService.Domain.Workspaces.ReadModels;

namespace NgCrm.BasicInfoService.Api.Controllers
{
    [ApiController]
    [Route("api/v1/workspace")]
    public class WorkspaceController : GoldiranController<WorkspaceController>
    {
        public WorkspaceController(ISender sender, ILogger<WorkspaceController> logger) : base(sender, logger)
        {

        }

        [HttpPost("create")]
        public async Task<ActionResult<bool>> Create([FromBody] CreateWorkspaceCommand request, CancellationToken cancellationToken)
        {
            return await Sender.Send(request, cancellationToken);
        }

        [HttpPost("create-with-permission")]
        public async Task<ActionResult<bool>> CreateWithPermission([FromBody] CreateWorkspaceWithPermissionCommand request, CancellationToken cancellationToken)
        {
            return await Sender.Send(request, cancellationToken);
        }

        [HttpGet("get")]
        public async Task<ActionResult<IEnumerable<WorkspaceBriefDto>>> Get([FromQuery] GetWorkspaceQuery request, CancellationToken cancellationToken)
        {
            return (await Sender.Send(request, cancellationToken)).ToList();
        }

        [HttpGet("get-by-id")]
        public async Task<ActionResult<WorkspaceReadModel?>> GetById(long id, CancellationToken cancellationToken)
        {
            return await Sender.Send(new GetWorkspaceByIdQuery { Id = id }, cancellationToken);
        }

        [HttpGet("permission-history")]
        public async Task<ActionResult<IEnumerable<long>>> GetPermissionHistory([FromQuery] GetWorkspacePermissionHistoryQuery request, CancellationToken cancellationToken)
        {
            return (await Sender.Send(request, cancellationToken)).ToList();
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<bool>> Delete([FromQuery] DeleteWorkspaceCommand request, CancellationToken cancellationToken)
        {
            return await Sender.Send(request, cancellationToken);
        }

        [HttpPut("update")]
        public async Task<ActionResult<bool>> Update([FromBody] UpdateWorkspaceCommand request, CancellationToken cancellationToken)
        {
            return await Sender.Send(request, cancellationToken);
        }

        [HttpPut("update-with-permission")]
        public async Task<ActionResult<bool>> UpdateWithPermission([FromBody] UpdateWorkspaceWithPermissionCommand request, CancellationToken cancellationToken)
        {
            return await Sender.Send(request, cancellationToken);
        }


        [HttpPut("set-permission-to-workspace")]
        public async Task<ActionResult<bool>> SetPermissionsToWorkspace([FromBody] SetPermissionsToWorkspaceCommand request, CancellationToken cancellationToken)
        {
            return await Sender.Send(request, cancellationToken);
        }
    }
}
