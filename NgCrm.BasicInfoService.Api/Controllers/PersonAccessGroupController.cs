using Goldiran.Framework.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NgCrm.BasicInfoService.Application.PersonAccessGroups.Commands;
using NgCrm.BasicInfoService.Domain.PersonAccessGroups.Dtos;
using NgCrm.BasicInfoService.Domain.PersonAccessGroups.Queries;

namespace NgCrm.BasicInfoService.Api.Controllers
{
    [ApiController]
    [Route("api/v1/personaccessgroup")]
    public class PersonAccessGroupController : GoldiranController<PersonAccessGroupController>
    {
        public PersonAccessGroupController(ISender sender, ILogger<PersonAccessGroupController> logger) : base(sender, logger)
        {

        }

        [HttpGet("get")]
        public async Task<ActionResult<IEnumerable<PersonAccessGroupBriefDto>>> GetByDate(CancellationToken cancellationToken)
        {
            var result = await Sender.Send(new GetPersonAccessGroupQuery(), cancellationToken);
            return result.ToList();
        }

        [HttpPost("create")]
        public async Task<ActionResult<bool>> Create([FromBody] CreatePersonAccessGroupCommand request, CancellationToken cancellationToken)
        {
            return await Sender.Send(request, cancellationToken);
        }

        [HttpPost("create-person-accessgoups")]
        public async Task<ActionResult<bool>> CreatePersonAccessGroups([FromBody] CreatePersonAccessGroupsCommand request, CancellationToken cancellationToken)
        {
            return await Sender.Send(request, cancellationToken);
        }

        [HttpPost("create-accessgroup-persons")]
        public async Task<ActionResult<bool>> CreateAccessGroupPersons([FromBody] CreateAccessGroupPersonsCommand request, CancellationToken cancellationToken)
        {
            return await Sender.Send(request, cancellationToken);
        }
    }
}
