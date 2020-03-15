using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace weather_widget_backend.Models.Registration
{
    public class RegistrationResponse
    {
        public string data { get; set; }

        public RegistrationResponse(string data)
        {
            this.data = data;
        }
    }
}
