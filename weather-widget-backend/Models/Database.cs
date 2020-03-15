using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using weather_widget_backend.UserKeys;

namespace weather_widget_backend.Models
{
    public class Database
    {
        private static readonly string connectionString = Keys.ConnectionString;
        public static SqlConnection SqlConnection()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;

            return connection;
        }
    }

}
