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


namespace Malshinon.dal
{
    public class DalRepott
    {






        public MysqlData Mysql;
        public DalRepott(MysqlData mysql)
        {
            Mysql = mysql;
        }





        public void Report(string Codename)
        {
            string EnemyCode;
            int ReportId;
            int TargetId;
            DalPepole dalPepole = new DalPepole(Mysql);
            if (dalPepole.FindeName(Codename))
            {
               ReportId =  dalPepole.ReturnId(Codename);
            }
            else
            
            {
            Console.WriteLine("The code name is not found enter code name");
            ReportId = dalPepole.AddName();
            }

            Console.WriteLine("Enter EnemyCode");
            EnemyCode = Console.ReadLine();
            Console.WriteLine("Enter Text");
            string Text = Console.ReadLine();



            if (dalPepole.FindeName(EnemyCode))
            {
                TargetId = dalPepole.ReturnId(EnemyCode);
            }

            else
            {
            TargetId = dalPepole.AddName("target");
            }

            EnteringInformation(ReportId, TargetId, Text);
        }
    
        
        
        
        
        
        
        public void EnteringInformation(int ReportId, int TargetId,string Text)
        {
            MySqlConnection conn = Mysql.GetConnnection();
            var Query = new MySqlCommand(@"INSERT INTO intelreports(report_id,target_id,text) VALUES (@ReportId,@TargetId,@Text)",conn);
            Query.Parameters.AddWithValue("@ReportId", ReportId);
            Query.Parameters.AddWithValue("@TargetId", TargetId);
            Query.Parameters.AddWithValue("@Text", Text);
            Query.ExecuteNonQuery();
        }
    }

    

}


