using Goldiran.Framework.AspNetCore;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NgCrm.BasicInfoService.Domain.Locations.Queries;
using NgCrm.BasicInfoService.Domain.Locations.ReadModels;
using NgCrm.BasicInfoService.Proxy.Map.Contracts;
using NgCrm.BasicInfoService.Proxy.Map.Models;

namespace NgCrm.BasicInfoService.Api.Controllers
{
    [ApiController]
    [Route("api/v1/mapData")]
    public class MapDataController : GoldiranController<LocationController>
    {
        private readonly IMapDataProxy _mapDataProxy;
        public MapDataController(ISender sender, ILogger<LocationController> logger, IMapDataProxy mapDataProxy) : base(sender, logger)
        {
            _mapDataProxy = mapDataProxy;
        }


        [HttpGet("get-reverse-geocode")]
        public async Task<ActionResult<ReverseGeocodeResponseApiModel>> GetReverseGeocode([FromQuery] GeocodeRequestModel request, CancellationToken cancellationToken)
        {
           return await _mapDataProxy.ReverseGeocodeAsync(request);
            
        }

        [HttpGet("search")]
        public async Task<ActionResult<SearchResponseModel>> Search([FromQuery] SearchRequestModel request, CancellationToken cancellationToken)
        {
            return await _mapDataProxy.SearchAsync(request);
        }
    }
}
