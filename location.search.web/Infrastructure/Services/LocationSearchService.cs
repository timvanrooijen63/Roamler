using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using location.search.web.Models;
using Microsoft.Extensions.Logging;
using Nest;

namespace location.search.web.Infrastucture.Services
{
    public interface ILocationSearchService
    {
        Task<List<LocationResponse>> SearchLocations(GeoLocation locationQuery, int maxDistance, int pageSize);
    }
    public class LocationSearchService : ILocationSearchService
    {
        private readonly ILogger<LocationSearchService> _logger;
        private readonly ElasticClient _elasticClient;
        public LocationSearchService(ILogger<LocationSearchService> logger, ElasticClient elasticClient)
        {
            _logger = logger;
            _elasticClient = elasticClient;
        }

        public async Task<List<LocationResponse>> SearchLocations(GeoLocation locationQuery, int maxDistance, int pageSize)
        {
            var distance = $"{maxDistance}km";

            var response = await _elasticClient.SearchAsync<LocationResponse>(s => s
                            .Index("locations")
                            .From(0)
                            .Size(pageSize)
                             .ScriptFields(sf => sf
                                .ScriptField("distance", descriptor => descriptor
                                    .Source("doc['location'].arcDistance(params.lat,params.lon)")
                                    .Params(f => f.Add("lat", locationQuery.Latitude).Add("lon", locationQuery.Longitude))))
                            .Query(query => query.Bool(b => b.Filter(filter => filter
                                .GeoDistance(geo => geo
                                    .Field(f => f.Location)
                                    .Distance(distance).Location(locationQuery)
                                    .DistanceType(GeoDistanceType.Plane)))))
                             .Sort(so => so
                                .GeoDistance(g => g
                                    .Field(f => f.Location)
                                    .Points(locationQuery)
                                    .Ascending()
                                    .Unit(DistanceUnit.Meters)
                                    .Mode(SortMode.Min))));
          //  var debugInformation = response.DebugInformation;
          //  _logger.LogInformation(debugInformation.ToString());

            return response.Documents.ToList();

        }
    }
}