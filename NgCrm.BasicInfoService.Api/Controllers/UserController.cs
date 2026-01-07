using Goldiran.Framework.AspNetCore;
using Goldiran.Framework.Domain.Dtos;
using Goldiran.Framework.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NgCrm.BasicInfoService.Application.Users.Commands;
using NgCrm.BasicInfoService.Domain.ADUsers.Queries;
using NgCrm.BasicInfoService.Domain.Positions.Queries;
using NgCrm.BasicInfoService.Domain.Users.Dtos;
using NgCrm.BasicInfoService.Domain.Users.Queries;

namespace NgCrm.BasicInfoService.Api.Controllers
{
    [ApiController]
    [Route("api/v1/user")]
    public class UserController : GoldiranController<UserController>
    {
        public UserController(ISender sender, ILogger<UserController> logger) : base(sender, logger)
        {

        }

        [HttpGet("get")]
        public async Task<ActionResult<Paged<UserBriefDto>>> Get([FromQuery] GetUserQuery request, CancellationToken cancellationToken)
        {
            return await Sender.Send(request, cancellationToken);
        }


        [HttpGet("get-by-id")]
        public async Task<ActionResult<UserDto>> GetById([FromQuery] GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await Sender.Send(request, cancellationToken);
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResultDto>> Login([FromBody] LoginCommand request, CancellationToken cancellationToken)
        {
            return await Sender.Send(request, cancellationToken);
        }

        [HttpPost("create")]
        public async Task<ActionResult<bool>> Create([FromBody] CreateUserCommand request, CancellationToken cancellationToken)
        {
            return await Sender.Send(request, cancellationToken);
        }

        [HttpPost("update")]
        public async Task<ActionResult<bool>> Update([FromBody] UpdateUserCommand request, CancellationToken cancellationToken)
        {
            return await Sender.Send(request, cancellationToken);
        }

        [HttpGet("get-my-positions")]
        public async Task<ActionResult<IEnumerable<SelectItemDto>>> GetMyPositions(CancellationToken cancellationToken)
        {
            return (await Sender.Send(new GetMyPositionsQuery(), cancellationToken)).ToList();

        }

        [HttpPost("select-position")]
        public async Task<ActionResult<LoginResultDto>> SelectPosition([FromBody] SelectPositionCommand request, CancellationToken cancellationToken)
        {
            return await Sender.Send(request, cancellationToken);

        }

        [HttpGet("get-aduser-selectlist")]
        public async Task<ActionResult<IEnumerable<SelectItemDto>>> GetAdUserSelectList(string searchTerm, CancellationToken cancellationToken)
        {
            return (await Sender.Send(new GetADUserSelectListQuery() { SearchTerm = searchTerm }, cancellationToken)).ToList();
        }

        [HttpGet("get-user-selectlist")]
        public async Task<ActionResult<IEnumerable<SelectItemDto>>> GetUserSelectList([FromQuery] GetUserSelectListQuery request, CancellationToken cancellationToken)
        {
            return (await Sender.Send(request, cancellationToken)).ToList();
        }

        [HttpGet("get-permission-history")]
        public async Task<ActionResult<IEnumerable<long>>> GetPermissionHistory([FromQuery] GetUserPermissionHistoryQuery requst, CancellationToken cancellationToken)
        {
            return (await Sender.Send(requst, cancellationToken)).ToList();
        }
    }
}
