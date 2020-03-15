using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using weather_widget_backend.API.Kladr;
using weather_widget_backend.API.Kladr.Models;
using weather_widget_backend.Models.Search;

namespace weather_widget_backend.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        // GET: api/Search/searchString
        [HttpGet("{searchString}")]
        public string Get(string searchString)
        {
            Result[] cities = KladrAPI.GetCities(searchString, 5).result;
            List<SearchItem> responseList = new List<SearchItem>();
            for (int i = 0; i < cities.Length; i++)
            {
                responseList.Add(new SearchItem(cities[i].name));
            }
            responseList.Remove(responseList[0]);
            return JsonConvert.SerializeObject(new SearchResponse(responseList.ToArray()));
        }
    }
}
