using Nest;

namespace location.search.web.Models
{
    public class LocationResponse
    {
        public string Address { get; set; }

        public string Message  { get; set; }

        public int Distance { get; set; }

        public string Path { get; set; }
        public GeoLocation Location { get; set; }
    }
}