using Goldiran.Framework.AspNetCore;
using Goldiran.Framework.Domain.Dtos;
using Goldiran.Framework.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NgCrm.BasicInfoService.Application.AccessGroups.Commands;
using NgCrm.BasicInfoService.Domain.AccessGroups.Dtos;
using NgCrm.BasicInfoService.Domain.AccessGroups.Queries;
using NgCrm.BasicInfoService.Domain.Persons.Queries;
using NgCrm.BasicInfoService.Domain.Positions.Queries;

namespace NgCrm.BasicInfoService.Api.Controllers
{
    [ApiController]
    [Route("api/v1/accessgroup")]
    [Authorize]
    public class AccessGroupController : GoldiranController<AccessGroupController>
    {
        public AccessGroupController(ISender sender, ILogger<AccessGroupController> logger) : base(sender, logger)
        {

        }

        [HttpGet("get")]
        public async Task<ActionResult<Paged<AccessGroupBriefDto>>> Get([FromQuery] GetAccessGroupQuery request, CancellationToken cancellationToken)
        {
            return await Sender.Send(request, cancellationToken);
        }

        [HttpGet("get-by-id")]
        public async Task<ActionResult<AccessGroupDetailDto>> GetById([FromQuery] long id, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(new GetAccessGroupByIdQuery() { Id = id }, cancellationToken);
            return result;
        }


        [HttpPost("create")]
        public async Task<ActionResult<bool>> Create([FromBody] CreateAccessGroupCommand request, CancellationToken cancellationToken)
        {
            return await Sender.Send(request, cancellationToken);
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<bool>> Delete([FromQuery] DeleteAccessGroupCommand request, CancellationToken cancellationToken)
        {
            return await Sender.Send(request, cancellationToken);
        }

        [HttpPut("update")]
        public async Task<ActionResult<bool>> Update([FromBody] UpdateAccessGroupCommand request, CancellationToken cancellationToken)
        {
            return await Sender.Send(request, cancellationToken);
        }

        [HttpGet("get-access-group-selectlist")]
        public async Task<ActionResult<IEnumerable<SelectItemDto>>> GetAccessGroupSelectlist(string searchTerm, CancellationToken cancellationToken)
        {
            return (await Sender.Send(new GetAccessGroupsSelectListQuery() { SearchTerm = searchTerm }, cancellationToken)).ToList();
        }
    }
}
