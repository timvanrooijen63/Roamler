using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using location.search.web.Models;
using location.search.web.Infrastucture.Services;
using Nest;

namespace location.search.web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationSearchController : ControllerBase
    {
        private readonly ILogger<LocationSearchController> _logger;
        private readonly ILocationSearchService _locationSearchService;

        public LocationSearchController(ILogger<LocationSearchController> logger, ILocationSearchService locationSearchService)
        {
            _logger = logger;
            _locationSearchService = locationSearchService;
        }

        [HttpPost]
        public async Task<List<LocationResponse>> Search([FromBody] LocationSearchRequest request)
        {
            var location = new GeoLocation(request.Lat, request.Long);
            var result = await _locationSearchService.SearchLocations(location, request.Distance, request.PageSize);
            return result;
        }
    }
}