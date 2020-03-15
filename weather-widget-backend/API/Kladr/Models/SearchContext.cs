using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace weather_widget_backend.API.Kladr.Models
{
    public class SearchContext
    {
        public string query { get; set; }
        public string contentType { get; set; }
        public int withParent { get; set; }
        public int limit { get; set; }
    }
}
