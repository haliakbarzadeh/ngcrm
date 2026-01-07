using Goldiran.Framework.AspNetCore;
using Goldiran.Framework.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NgCrm.BasicInfoService.Application.PersonDelegates.Commands;
using NgCrm.BasicInfoService.Domain.PersonDelegates.Dtos;
using NgCrm.BasicInfoService.Domain.PersonDelegates.Queries;

namespace NgCrm.BasicInfoService.Api.Controllers
{
    [ApiController]
    [Route("api/v1/personDelegate")]
    public class PersonDelegateController : GoldiranController<PersonDelegateController>
    {
        public PersonDelegateController(ISender sender, ILogger<PersonDelegateController> logger) : base(sender, logger)
        {
        }

        [HttpPost("create")]
        public async Task<ActionResult<long>> Create([FromBody] CreatePersonDelegateCommand request, CancellationToken cancellationToken)
        {
            return await Sender.Send(request, cancellationToken);
        }

        [HttpGet("get")]
        public async Task<ActionResult<Paged<PersonDelegateBriefDto>>> Get([FromQuery] GetPersonDelegateQuery request, CancellationToken cancellationToken)
        {
            return await Sender.Send(request, cancellationToken);
        }

        [HttpGet("get-by-id")]
        public async Task<ActionResult<PersonDelegateDto>> Get(long id, CancellationToken cancellationToken)
        {
            return await Sender.Send(new GetPersonDelegateByIdQuery { Id = id }, cancellationToken);
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<bool>> Delete([FromQuery] DeletePersonDelegateCommand request, CancellationToken cancellationToken)
        {
            return await Sender.Send(request, cancellationToken);
        }

        [HttpPut("update")]
        public async Task<ActionResult<bool>> Update([FromBody] UpdatePersonDelegateCommand request, CancellationToken cancellationToken)
        {
            return await Sender.Send(request, cancellationToken);
        }
    }
}