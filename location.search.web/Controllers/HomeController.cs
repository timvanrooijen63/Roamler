using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using location.search.web.Models;
using Nest;
using location.search.web.Infrastucture.Services;

namespace location.search.web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILocationSearchService _locationSearchService;

        public HomeController(ILogger<HomeController> logger, ILocationSearchService locationSearchService)
        {
            _logger = logger;
            _locationSearchService = locationSearchService;
        }

        public async Task<IActionResult> Index()
        {
            var towerOfLondon = new GeoLocation(51.507313, -0.074308);
            var result = await _locationSearchService.SearchLocations(towerOfLondon, 10, 1000);

            return View();
        }




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
