using Goldiran.Framework.AspNetCore;
using Goldiran.Framework.Domain.Dtos;
using Goldiran.Framework.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NgCrm.BasicInfoService.Domain.ADUsers.Dtos;
using NgCrm.BasicInfoService.Domain.ADUsers.Queries;
using NgCrm.BasicInfoService.Domain.Positions.Queries;

namespace NgCrm.BasicInfoService.Api.Controllers
{
    [ApiController]
    [Route("api/v1/aduser")]
    public class ADUserController : GoldiranController<ADUserController>
    {
        public ADUserController(ISender sender, ILogger<ADUserController> logger) : base(sender, logger)
        {

        }

        [HttpGet("get")]
        public async Task<ActionResult<Paged<ADUserBriefDto>>> Create([FromQuery] GetADUserQuery request, CancellationToken cancellationToken)
        {
            return await Sender.Send(request, cancellationToken);
        }
    }
}
