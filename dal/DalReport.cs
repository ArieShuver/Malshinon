using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Malshinon.models;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using Org.BouncyCastle.Asn1.X509;
using static System.Net.Mime.MediaTypeNames;


namespace Malshinon.models
{
    public class DalRepott
    {






        public MysqlData Mysql;
        public DalRepott(MysqlData mysql)
        {
            Mysql = mysql;
        }







        public void EnteringInformation(int ReportId, int TargetId, string Text)
        {
            try
            {
                MySqlConnection conn = Mysql.GetConnnection();
                var Query = new MySqlCommand(@"INSERT INTO intelreports(report_id,target_id,text) VALUES (@ReportId,@TargetId,@Text)", conn);
                Query.Parameters.AddWithValue("@ReportId", ReportId);
                Query.Parameters.AddWithValue("@TargetId", TargetId);
                Query.Parameters.AddWithValue("@Text", Text);
                Query.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                {
                    Console.WriteLine("erorr" + ex.Message);
                }
            }
            finally
            {
                Mysql.CloseConn();
            }
        }


    }
}






