using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
namespace Malshinon.models
{
    public class MysqlData
    {
        public string connectionString = "Server=localhost;Database=malshinon;User=root;Password='';";
        public MySqlConnection connection;
        public MySqlConnection GetConnnection()
        {
            try
            {
                var conn = new MySqlConnection(connectionString);
                connection = conn;
                connection.Open();
                return connection;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"error{ex.Message}");
                return connection;
            }
        }
             public void CloseConn()
        {
            connection.Close();
        }
    }
}
