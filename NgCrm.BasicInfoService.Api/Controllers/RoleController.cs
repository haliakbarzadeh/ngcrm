using Goldiran.Framework.AspNetCore;
using Goldiran.Framework.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NgCrm.BasicInfoService.Application.Roles.Commands;
using NgCrm.BasicInfoService.Domain.Roles.Dtos;
using NgCrm.BasicInfoService.Domain.Roles.Queries;
using NgCrm.BasicInfoService.Domain.Roles.ReadModels;

namespace NgCrm.BasicInfoService.Api.Controllers
{
    [ApiController]
    [Route("api/v1/role")]
    public class RoleController : GoldiranController<RoleController>
    {
        public RoleController(ISender sender, ILogger<RoleController> logger) : base(sender, logger)
        {

        }

        [HttpPost("create")]
        public async Task<ActionResult<bool>> Create([FromBody] CreateRoleCommand request, CancellationToken cancellationToken)
        {
            return await Sender.Send(request, cancellationToken);
        }

        [HttpGet("get")]
        public async Task<ActionResult<Paged<RoleBriefDto>>> Get([FromQuery] GetRoleQuery request, CancellationToken cancellationToken)
        {
            return await Sender.Send(request, cancellationToken);
        }

        //[HttpGet("get-by-id/{id}")]
        //public async Task<ActionResult<CustomerReadModel>> GetById([FromRoute] int id, CancellationToken cancellationToken)
        //{
        //    return await Sender.Send(new GetCustomerByIdQuery() { Id = id }, cancellationToken);
        //}

        //[HttpGet("get-addresses")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<ActionResult<IList<CustomerAddressReadModel>>> GetAddresses([FromQuery] GetCustomerAddressesByIdQuery request, CancellationToken cancellationToken)
        //{
        //    return await Sender.Send(request);
        //}

        //[HttpGet("get-by-mobile")]
        //public async Task<ActionResult<CustomerReadModel>> GetByMobile([FromQuery] GetCustomerByMobileQuery request, CancellationToken cancellationToken)
        //{
        //    return await Sender.Send(request, cancellationToken);
        //}
    }
}
