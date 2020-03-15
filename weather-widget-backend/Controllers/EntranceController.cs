using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Cors;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using weather_widget_backend.Models.Entrance;
using System.Data.SqlClient;
using weather_widget_backend.Models;

namespace weather_widget_backend.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class EntranceController : ControllerBase
    {
        // GET: api/Entrance/email=...&password=...
        [HttpGet("{searchString}")]
        public string Get(string searchString)
        {
            string[] parameters;
            string email;
            string password;

            try
            {
                parameters = searchString.Split('&');
                email = parameters[0].Split('=')[1];
                password = parameters[1].Split('=')[1];
                if (parameters[0].Split('=')[0] != "email" || parameters[1].Split('=')[0] != "password")
                {
                    return JsonConvert.SerializeObject(new EntranceResponse("incorrect request"));
                }
            }
            catch
            {
                return JsonConvert.SerializeObject(new EntranceResponse("incorrect request"));
            }

            SqlConnection connection = Database.SqlConnection();

            SqlCommand command;
            connection.Open();
            string sql = "SELECT [Users].[Login] FROM dbo.Users " +
                $"WHERE [Users].[Email] = N'{email}' AND [Users].[Password] = N'{password}'";
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
                response = "incorrect password";
            }
            connection.Close();

            return JsonConvert.SerializeObject(new EntranceResponse(response));
        }

    }
}
