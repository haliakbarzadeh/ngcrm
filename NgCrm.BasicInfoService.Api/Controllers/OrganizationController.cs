using Goldiran.Framework.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NgCrm.BasicInfoService.Application.Organizations.Commands;
using NgCrm.BasicInfoService.Domain.OrganizationHistories.Dtos;
using NgCrm.BasicInfoService.Domain.OrganizationHistories.Queries;
using NgCrm.BasicInfoService.Domain.Organizations.Dtos;
using NgCrm.BasicInfoService.Domain.Organizations.Queries;

namespace NgCrm.BasicInfoService.Api.Controllers
{
    [ApiController]
    [Route("api/v1/organization")]
    public class OrganizationController : GoldiranController<OrganizationController>
    {
        public OrganizationController(ISender sender, ILogger<OrganizationController> logger) : base(sender, logger)
        {

        }

        [HttpPost("create")]
        public async Task<ActionResult<bool>> Create([FromBody] CreateOrganizationCommand request, CancellationToken cancellationToken)
        {
            return await Sender.Send(request, cancellationToken);
        }

        [HttpGet("get")]
        public async Task<ActionResult<IEnumerable<OrganizationBriefDto>>> Get(CancellationToken cancellationToken)
        {
            var list = await Sender.Send(new GetOrganizationQuery(), cancellationToken);

            return list.ToList();
        }


        [HttpGet("get-by-id")]
        public async Task<ActionResult<OrganizationDto>> Get(long id, CancellationToken cancellationToken)
        {
            return await Sender.Send(new GetOrganizationByIdQuery { Id = id });
        }


        [HttpDelete("delete")]
        public async Task<ActionResult<bool>> Delete([FromQuery] DeleteOrganizationCommand request, CancellationToken cancellationToken)
        {
            return await Sender.Send(request, cancellationToken);
        }

        [HttpPatch("update")]
        public async Task<ActionResult<bool>> Update([FromBody] UpdateOrganizationCommand request, CancellationToken cancellationToken)
        {
            return await Sender.Send(request, cancellationToken);
        }


        [HttpGet("get-by-date")]
        public async Task<ActionResult<OrganizationHistoryDto>> GetByDate(DateTime fromdate, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(new GetOrganizationHistoryByDateQuery() { FromDate = fromdate }, cancellationToken);

            return result;
        }
    }
}
