using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using location.search.web.Models;
using Nest;

namespace location.search.web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ElasticClient _elasticClient;



        public HomeController(ILogger<HomeController> logger, ElasticClient elasticClient)
        {
            _logger = logger;
            _elasticClient = elasticClient;
        }

        public IActionResult Index()
        {
            var result = GetLocations(10,1000);

            return View();
        }

        private List<LocationResponse>  GetLocations(int maxDistance, int maxResults)
        {
            var response = _elasticClient.Search<LocationResponse>(s => s
                            .Index("locations")
                            .From(0)
                            .Size(1000)
                            .Query(query => query.Bool(b => b.Filter(filter => filter
                                .GeoDistance(geo => geo
                                    .Field(f => f.Location) 
                                    .Distance("20km").Location(52.6702278, 4.7011616)
                                    .DistanceType(GeoDistanceType.Plane)
                        ))
                )));

            var debugInformation = response.DebugInformation;
            _logger.LogInformation(debugInformation.ToString());
            
            return response.Documents.ToList();
                        
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
