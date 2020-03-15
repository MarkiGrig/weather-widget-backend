using System.Net;
using Newtonsoft.Json;

namespace weather_widget_backend.API.Kladr
{
    class KladrAPI: API
    {
        private static readonly string apiAddress = "https://kladr-api.ru/api.php";

        public static KladrAPIResponse GetCities(string query, int limit = 5)
        {
            return JsonConvert.DeserializeObject<KladrAPIResponse>(GetResponseJson(RequestCities(query, limit)));
        }

        private static WebResponse RequestCities(string query, int limit)
        {
            string requestParams = $"query={query}" +
                $"&contentType=city" +
                "&withPatent=1" +
                $"&limit={limit}";

            WebRequest request = SetRequest(requestParams);

            return request.GetResponse();
        }

        private static WebRequest SetRequest(string requestParams)
        {
            WebRequest request = WebRequest.Create($"{apiAddress}?{requestParams}");
            request.Method = "GET";

            return request;
        }
    }
}
