using Goldiran.Framework.AspNetCore;
using Goldiran.Framework.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NgCrm.BasicInfoService.Application.Departments.Commands;
using NgCrm.BasicInfoService.Domain.Departments.Dtos;
using NgCrm.BasicInfoService.Domain.Departments.Queries;

namespace NgCrm.BasicInfoService.Api.Controllers
{
    [ApiController]
    [Route("api/v1/department")]
    public class DepartmentController : GoldiranController<DepartmentController>
    {
        public DepartmentController(ISender sender, ILogger<DepartmentController> logger) : base(sender, logger)
        {
        }

        [HttpPost("create")]
        public async Task<ActionResult<bool>> Create([FromBody] CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            return await Sender.Send(request, cancellationToken);
        }

        [HttpGet("get")]
        public async Task<ActionResult<Paged<DepartmentBriefDto>>> Get(GetDepartmentQuery request, CancellationToken cancellationToken)
        {
            return await Sender.Send(request, cancellationToken);
        }

        [HttpGet("get-by-id")]
        public async Task<ActionResult<DepartmentDto>> Get(long id, CancellationToken cancellationToken)
        {
            return await Sender.Send(new GetDepartmentByIdQuery { Id = id });
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<bool>> Delete([FromQuery] DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            return await Sender.Send(request, cancellationToken);
        }

        [HttpPatch("update")]
        public async Task<ActionResult<bool>> Update([FromBody] UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            return await Sender.Send(request, cancellationToken);
        }

    }
}