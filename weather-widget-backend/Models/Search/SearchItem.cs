using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace weather_widget_backend.Models.Search
{
    public class SearchItem
    {
        public string name { get; set; }

        public SearchItem(string name)
        {
            this.name = name;
        }
    }
}
