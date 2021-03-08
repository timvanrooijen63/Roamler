using Nest;

namespace location.search.web.Models
{
    public class LocationResponse
    {
        public string Address { get; set; }
        public GeoLocation Location { get; set; }
        
        public string Distance { get; set; }
    }
}