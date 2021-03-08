using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpGet]
        public async Task<List<LocationResponse>> Get()
        {
            var towerOfLondon = new GeoLocation(51.507313, -0.074308);
            var result = await _locationSearchService.SearchLocations(towerOfLondon, 10, 5);
            return result;
        }

    }
}