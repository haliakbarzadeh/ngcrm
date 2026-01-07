using Goldiran.Framework.AspNetCore;
using Goldiran.Framework.Domain.Dtos;
using Goldiran.Framework.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NgCrm.BasicInfoService.Application.Persons.Commands;
using NgCrm.BasicInfoService.Domain.Persons.Dtos;
using NgCrm.BasicInfoService.Domain.Persons.Queries;

namespace NgCrm.BasicInfoService.Api.Controllers
{
    [ApiController]
    [Route("api/v1/person")]
    public class PersonController : GoldiranController<PersonController>
    {
        public PersonController(ISender sender, ILogger<PersonController> logger) : base(sender, logger)
        {

        }

        [HttpPost("create")]
        public async Task<ActionResult<long>> Create([FromBody] CreatePersonCommand request, CancellationToken cancellationToken)
        {
            return await Sender.Send(request, cancellationToken);
        }


        [HttpGet("get")]
        public async Task<ActionResult<Paged<PersonBriefDto>>> Get([FromQuery] GetPersonQuery request, CancellationToken cancellationToken)
        {
            return await Sender.Send(request, cancellationToken);
        }

        [HttpGet("get-persons-selectlist")]
        public async Task<ActionResult<IEnumerable<SelectItemDto>>> GetPersonSelectList([FromQuery] GetPersonSelectListQuery request, CancellationToken cancellationToken)
        {
            return (await Sender.Send(request, cancellationToken)).ToList();
        }

        [HttpGet("get-by-id")]
        public async Task<ActionResult<PersonDto>> GetById(long id, CancellationToken cancellationToken)
        {
            return await Sender.Send(new GetPersonByIdQuery { Id = id }, cancellationToken);
        }

        [HttpGet("get-by-nationalcode")]
        public async Task<ActionResult<PersonDto>> GetByNationalCode(string nationalCode, CancellationToken cancellationToken)
        {
            return await Sender.Send(new GetPersonByNationalCodeQuery { NationalCode = nationalCode }, cancellationToken);
        }

        [HttpGet("get-by-personalcode")]
        public async Task<ActionResult<PersonDto>> GetByPersonalCode(string personalCode, CancellationToken cancellationToken)
        {
            return await Sender.Send(new GetPersonByPersonalCodeQuery { PersonalCode = personalCode }, cancellationToken);
        }


        [HttpPut("update")]
        public async Task<ActionResult<bool>> Update([FromBody] UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            return await Sender.Send(request, cancellationToken);
        }


        [HttpDelete("delete")]
        public async Task<ActionResult<bool>> Delete([FromQuery] DeletePersonCommand request, CancellationToken cancellationToken)
        {
            return await Sender.Send(request, cancellationToken);
        }


        [HttpPatch("change-person-activation")]
        public async Task<ActionResult<bool>> ChangePersonActivation([FromBody] ToggleIsActivePersonCommand request, CancellationToken cancellationToken)
        {
            return await Sender.Send(request, cancellationToken);
        }


        [HttpGet("get-permissions-by-person-id")]
        public async Task<ActionResult<IEnumerable<PersonPermissionDto>>> GetPermissionsByPersonId([FromQuery] GetPermissionsByPersonIdQuery request, CancellationToken cancellationToken)
        {
            return (await Sender.Send(request, cancellationToken)).ToList();
        }


        [HttpPatch("add-person-position-permissions")]
        public async Task<ActionResult<bool>> AddPersonPositionPermissions([FromBody] AddPersonPositionPermissionsCommand request, CancellationToken cancellationToken)
        {
            return await Sender.Send(request, cancellationToken);
        }


        [HttpGet("get-person-positions-selectlist")]
        public async Task<ActionResult<IEnumerable<SelectItemDto>>> GetPersonPositionSelectList([FromQuery] GetPersonPositionsQuery request, CancellationToken cancellationToken)
        {
            return (await Sender.Send(request, cancellationToken)).ToList();
        }

        [HttpGet("get-my-child-persons-selectlist")]
        public async Task<ActionResult<IEnumerable<SelectItemDto>>> GetMyChildPersons(CancellationToken cancellationToken)
        {
            return (await Sender.Send(new GetMyChildPersonsQuery(), cancellationToken)).ToList();
        }

        [HttpGet("get-person-summary-list")]
        public async Task<ActionResult<IEnumerable<PersonSummaryDto>>> GetPersonSummaryList([FromQuery] string searchTerm, CancellationToken cancellationToken)
        {
            return (await Sender.Send(new GetPersonSummaryQuery() { SearchTerm = searchTerm }, cancellationToken)).ToList();
        }



    }
}
