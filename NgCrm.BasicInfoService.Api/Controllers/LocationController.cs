using Goldiran.Framework.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NgCrm.BasicInfoService.Domain.Locations.Dtos;
using NgCrm.BasicInfoService.Domain.Locations.Queries;
using NgCrm.BasicInfoService.Domain.Locations.ReadModels;
using NgCrm.BasicInfoService.Proxy.Map;

namespace NgCrm.BasicInfoService.Api.Controllers
{
    [ApiController]
    [Route("api/v1/location")]
    public class LocationController : GoldiranController<LocationController>
    {
              
        public LocationController(ISender sender, ILogger<LocationController> logger) : base(sender, logger)
        {
           
        }

        //[HttpPost("get-all-locations")]
        //public async Task<ActionResult<IList<LocationReadModel>>> GetRegions([FromQuery] GetAllLocationsQuery request, CancellationToken cancellationToken)
        //{
        //    return (await Sender.Send(request, cancellationToken)).ToList();
        //}

        [HttpGet("get-provinces")]
        public async Task<ActionResult<IList<LocationBriefDto>>> GetProvinces([FromQuery] GetProvincesQuery request, CancellationToken cancellationToken)
        {
            return (await Sender.Send(request, cancellationToken)).ToList();
        }

        [HttpGet("get-cities")]
        public async Task<ActionResult<IList<LocationBriefDto>>> GetCities([FromQuery] GetCitiesQuery request, CancellationToken cancellationToken)
        {
            return (await Sender.Send(request, cancellationToken)).ToList();
        }

        //[HttpPost("get-regions")]
        //public async Task<ActionResult<IList<LocationReadModel>>> GetRegions([FromQuery] GetRegionsQuery request, CancellationToken cancellationToken)
        //{
        //    return (await Sender.Send(request, cancellationToken)).ToList();
        //}



    }
}
