using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Cors;
using weather_widget_backend.Models.Email;
using System.Data.SqlClient;
using weather_widget_backend.Models;

namespace weather_widget_backend.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        // GET: api/Email/searchString
        [HttpGet("{searchString}")]
        public string Get(string searchString)
        {
            SqlConnection connection = Database.SqlConnection();

            SqlCommand command;
            connection.Open();
            string sql = $"SELECT [Users].[Email] FROM dbo.Users WHERE [Users].[Email] = N'{searchString}'";
            command = new SqlCommand(sql, connection);

            SqlDataReader dataReader = command.ExecuteReader();
            string response = "";
            while (dataReader.Read())
            {
                if (dataReader.GetSqlValue(0) != null)
                {
                    response = dataReader.GetSqlValue(0).ToString();
                }
                else
                {
                    response = "error";
                }
            }
            if (response.Length == 0)
            {
                response = "email is not registered";
            }
            connection.Close();

            return JsonConvert.SerializeObject(new EmailResponse(response));
        }
    }
}
