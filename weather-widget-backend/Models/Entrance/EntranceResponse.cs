using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace weather_widget_backend.Models.Entrance
{
    public class EntranceResponse
    {
        public string data { get; set; }

        public EntranceResponse(string data)
        {
            this.data = data;
        }
    }
}
