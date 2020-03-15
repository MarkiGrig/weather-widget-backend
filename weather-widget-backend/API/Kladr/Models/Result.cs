using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace weather_widget_backend.API.Kladr.Models
{
    public class Result: Region
    {
        Region[] parents { get; set; }
    }
}
