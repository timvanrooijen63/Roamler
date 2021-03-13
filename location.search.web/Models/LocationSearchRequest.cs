using Nest;

namespace location.search.web.Models
{
    public class LocationSearchRequest
    {
        public double Lat { get; set; }    
        public double Long { get; set; }    

        public int PageSize { get; set; }    
        public int Distance { get; set; }    
    }
}