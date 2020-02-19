using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace weather_widget_backend.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        // GET: api/Search
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Search/searchString
        [HttpGet("{searchString}", Name = "Get")]
        public string Get(string searchString)
        {
            return searchString;
        }
    }
}
