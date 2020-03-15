using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace weather_widget_backend.Models.Email
{
    public class EmailResponse
    {
        public string data { get; set; }

        public EmailResponse(string data)
        {
            this.data = data;
        }
    }
}
