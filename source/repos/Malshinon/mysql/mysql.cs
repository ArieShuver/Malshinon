using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
namespace Malshinon.mysql
{
    public class mysql
    {
        static string connectionString = "Server=localhost;Database=Malshinon;User=rootPasswprd='';Port=3306;";
        static MySqlConnection connection;
        static MySqlConnection GetConnnection()
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
