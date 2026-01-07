using Goldiran.Framework.AspNetCore;
using Goldiran.Framework.Domain.Models;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NgCrm.BasicInfoService.Application.BasicInfos.Commands;
using NgCrm.BasicInfoService.Domain.BaseInfos.Dtos;
using NgCrm.BasicInfoService.Domain.BaseInfos.Queries;

namespace NgCrm.BasicInfoService.Api.Controllers
{
    [ApiController]
    [Route("api/v1/baseinfo")]
    public class BaseInfoController : GoldiranController<BaseInfoController>
    {
        public BaseInfoController(ISender sender, ILogger<BaseInfoController> logger) : base(sender, logger)
        {

        }

        [HttpPost("create")]
        public async Task<ActionResult<bool>> Create([FromBody] CreateBaseInfoCommand request, CancellationToken cancellationToken)
        {
            return await Sender.Send(request, cancellationToken);
        }

        [HttpGet("get-with-paged")]
        public async Task<ActionResult<Paged<BaseInfoDto>>> GetWithPaged([FromQuery] GetBaseInfoQuery request, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(request, cancellationToken);

            return result.Adapt<Paged<BaseInfoDto>>();
        }


        [HttpGet("get-by-id")]
        public async Task<ActionResult<BaseInfoDto>> GetById(int id, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(new GetBaseInfoByIdQuery() { Id = id }, cancellationToken);

            return result;
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<bool>> Delete([FromQuery] DeleteBaseInfoCommand request, CancellationToken cancellationToken)
        {
            return await Sender.Send(request, cancellationToken);
        }

        [HttpPut("update")]
        public async Task<ActionResult<bool>> Update([FromBody] UpdateBaseInfoCommand request, CancellationToken cancellationToken)
        {
            return await Sender.Send(request, cancellationToken);
        }

    }
}
