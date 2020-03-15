using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Cors;
using weather_widget_backend.Models.Registration;
using System.Data.SqlClient;
using weather_widget_backend.Models;

namespace weather_widget_backend.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        // GET: api/Registration/email=...&password=...&login=...
        [HttpGet("{searchString}")]
        public string Get(string searchString)
        {
            string[] parameters;
            string email;
            string password;
            string login;

            try
            {
                parameters = searchString.Split('&');
                email = parameters[0].Split('=')[1];
                password = parameters[1].Split('=')[1];
                login = parameters[2].Split('=')[1];
                if (parameters[0].Split('=')[0] != "email" ||
                    parameters[1].Split('=')[0] != "password" ||
                    parameters[2].Split('=')[0] != "login")
                {
                    return JsonConvert.SerializeObject(new RegistrationResponse("incorrect request"));
                }
            }
            catch
            {
                return JsonConvert.SerializeObject(new RegistrationResponse("incorrect request"));
            }

            SqlConnection connection = Database.SqlConnection();
            connection.Open();

            string tableName = "Users";
            string sqlGetMaxID = $"SELECT MAX(Id) FROM dbo.{tableName}";
            int maxID = -1;

            using (SqlCommand cmd = new SqlCommand(sqlGetMaxID, connection))
            {
                SqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    maxID = Int32.Parse(dataReader.GetSqlValue(0).ToString());
                }
                dataReader.Close();
            }

            connection.Close();
            connection.Open();


            string sqlInsert = $"INSERT INTO dbo.{tableName} (dbo.{tableName}.Id, dbo.{tableName}.Email, " +
                $"dbo.{tableName}.Login, dbo.{tableName}.Password, dbo.{tableName}.RegistrationDate) " +
                "VALUES (@Id, @Email, @Login, @Password, DATEFROMPARTS(@Year, @Month, @Day))";

            using (SqlCommand cmd = new SqlCommand(sqlInsert, connection))
            {
                //DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                cmd.Parameters.AddWithValue("@Id", maxID + 1);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Login", login);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@Year", DateTime.Now.Year);
                cmd.Parameters.AddWithValue("@Month", DateTime.Now.Month);
                cmd.Parameters.AddWithValue("@Day", DateTime.Now.Day);

                cmd.ExecuteNonQuery();
            }
            return JsonConvert.SerializeObject(new RegistrationResponse("user registered successfully"));
        }
    }
}
