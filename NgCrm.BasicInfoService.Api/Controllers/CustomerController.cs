using Goldiran.Framework.AspNetCore;
using Goldiran.Framework.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NgCrm.BasicInfoService.Application.Customers.Commands;
using NgCrm.BasicInfoService.Domain.Customers.Dtos;
using NgCrm.BasicInfoService.Domain.Customers.Queries;
using System.Text.Json.Nodes;

namespace NgCrm.BasicInfoService.Api.Controllers
{
    [ApiController]
    [Route("api/v1/customer")]
    public class CustomerController : GoldiranController<CustomerController>
    {
        public CustomerController(ISender sender, ILogger<CustomerController> logger) : base(sender, logger)
        {

        }

        [HttpPost("create")]
        public async Task<ActionResult<long>> Create([FromBody] CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            return await Sender.Send(request, cancellationToken);
        }

        [HttpGet("get")]
        public async Task<ActionResult<Paged<CustomerDto>>> Get([FromQuery] GetCustomerQuery request, CancellationToken cancellationToken)
        {
            return await Sender.Send(request, cancellationToken);
        }

        [HttpGet("get-by-id")]
        public async Task<ActionResult<CustomerDto>> GetById(long id, CancellationToken cancellationToken)
        {
            return await Sender.Send(new GetCustomerByIdQuery { Id = id }, cancellationToken);
        }

        [HttpPut("update")]
        public async Task<ActionResult<bool>> Update([FromBody] UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            return await Sender.Send(request, cancellationToken);
        }

        [HttpPut("addaddress")]
        public async Task<ActionResult<bool>> AddAdrress([FromBody] AddCustomerAddressCommand request, CancellationToken cancellationToken)
        {
            return await Sender.Send(request, cancellationToken);
        }

        [HttpPut("addcontact")]
        public async Task<ActionResult<bool>> AddContact([FromBody] AddCustomerContactCommand request, CancellationToken cancellationToken)
        {
            return await Sender.Send(request, cancellationToken);
        }

        [HttpPut("addrelation")]
        public async Task<ActionResult<bool>> AddRelations([FromBody] AddCustomerRelationCommand request, CancellationToken cancellationToken)
        {
            return await Sender.Send(request, cancellationToken);
        }


        [HttpDelete("delete")]
        public async Task<ActionResult<bool>> Delete([FromQuery] DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            return await Sender.Send(request, cancellationToken);
        }


        [HttpPatch("change-Customer-activation")]
        public async Task<ActionResult<bool>> ChangeCustomerActivation([FromBody] ToggleIsActiveCustomerCommand request, CancellationToken cancellationToken)
        {
            return await Sender.Send(request, cancellationToken);
        }
    }
}
