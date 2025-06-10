using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using MySql.Data.MySqlClient;
using static System.Net.Mime.MediaTypeNames;


namespace Malshinon.models
{

    public class DalPepole
    {
        public MysqlData Mysql;
        public DalPepole(MysqlData mysql)
        {
            Mysql = mysql;
        }

        public bool ExaminationName(string CodeName)
        {
            try
            {
                MySqlConnection conn = Mysql.GetConnnection();
                var Query = new MySqlCommand("SELECT secret_code FROM people", conn);
                var reader = Query.ExecuteReader();

                while (reader.Read())
                {
                    if (reader.GetString("secret_code") == CodeName)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("erorr" + ex.Message);
                return false;
            }
            finally
            {
                Mysql.CloseConn();
            }
        }









        public string CodeGeneration(string name)
        {
            Random rand = new Random();
            string CodeName = name[0].ToString() + rand.Next(100, 2000);
            //Console.WriteLine(CodeName);
            return CodeName;
        }







        public void NameSearch(string CodeName)
        {

            if (! ExaminationName(CodeName))
            {
                AddName();

            }
            
        }




        public void AddName(string type = "reporter")
        {
            try
            {
                Console.WriteLine("Enter firstn_name");
                string firstnname = Console.ReadLine();
                Console.WriteLine("Enter last_name");
                string lastname = Console.ReadLine();
                MySqlConnection conn = Mysql.GetConnnection();
                var Query = new MySqlCommand(@"INSERT INTO people (firstn_name,last_name,secret_code,type) VALUES (@firstnname,@lastname,@CodeGeneration,@type)", conn);
                Query.Parameters.AddWithValue("@firstnname", firstnname);
                Query.Parameters.AddWithValue("@lastname", lastname);
                Query.Parameters.AddWithValue("@CodeGeneration", CodeGeneration(firstnname));
                Query.Parameters.AddWithValue("@type", type);
                Query.ExecuteNonQuery();
            }


            catch (Exception ex)
            {
                Console.WriteLine("error" + ex.Message);
            }
            finally
            {
                Mysql.CloseConn();
            }






        }
        public void Report(string Codename)
        {
            if (ExaminationName(Codename))
            {
                Console.WriteLine("Enter Name Enemy");
                string EnemyName = Console.ReadLine();
                Console.WriteLine("Enter Text");
                string Text =  Console.ReadLine();
                string CodeName = Codename;

            }
            else
            {
                Console.WriteLine("The code name is not found");
                AddName();
                Console.WriteLine("Enter Name Enemy");
                string EnemyName = Console.ReadLine();
                Console.WriteLine("Enter Text");
                string Text = Console.ReadLine();
                string CodeName = Codename;

            }
        }

    }
}

