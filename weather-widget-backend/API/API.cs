using System.Net;
using System.IO;

namespace weather_widget_backend.API
{
    abstract class API
    {
        protected static string GetResponseJson(WebResponse response)
        {
            string responseJson;

            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    responseJson = reader.ReadToEnd();
                }
            }

            response.Close();
            return responseJson;
        }
    }
}
