using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace weather_widget_backend.Models.Search
{
    public class SearchResponse
    {
        public SearchItem[] cities { get; set; }

        public SearchResponse(SearchItem[] cities)
        {
            this.cities = cities;
        }
    }
}
