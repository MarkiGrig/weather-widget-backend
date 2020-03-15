using weather_widget_backend.API.Kladr.Models;

namespace weather_widget_backend.API.Kladr
{
    public class KladrAPIResponse
    {
        public SearchContext searchContext { get; set; }
        public Result[] result { get; set; }
    }
}
