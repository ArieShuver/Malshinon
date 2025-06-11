using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
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



        public bool FindeName(string CodeName)   //בדיקה אם שם קיים
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









        public string CodeGeneration(string name)  //שם קוד 
        {
            Random rand = new Random();
            string CodeName = name[0].ToString() + rand.Next(100, 2000);
            //Console.WriteLine(CodeName);
            return CodeName;
        }









        public int AddName(string type = "reporter")
        {
            int Id = -1;
            try
            {
                MySqlConnection conn = Mysql.GetConnnection();

                Console.WriteLine("Enter firstn_name");
                string firstnname = Console.ReadLine();
                Console.WriteLine("Enter last_name");
                string lastname = Console.ReadLine();
                string CodeName = CodeGeneration(firstnname);


                var Query = new MySqlCommand(@"INSERT INTO people (firstn_name,last_name,secret_code,type) VALUES (@firstnname,@lastname,@CodeGeneration,@type)", conn);
                Query.Parameters.AddWithValue("@firstnname", firstnname);
                Query.Parameters.AddWithValue("@lastname", lastname);
                Query.Parameters.AddWithValue("@CodeGeneration",CodeName);
                Query.Parameters.AddWithValue("@type", type);
                Query.ExecuteNonQuery();



                var Cmd = new MySqlCommand(@"SELECT id FROM people WHERE secret_code = @CodeName", conn);
                Cmd.Parameters.AddWithValue("@CodeName", CodeName);
                var ReaderId = Cmd.ExecuteReader();
                if (ReaderId.Read())
                {
                    Id = ReaderId.GetInt32("id");
                    return Id;
                }
                //ReturnId(CodeName);

            }


            catch (Exception ex)
            {
                Console.WriteLine("error" + ex.Message);
            }
            finally
            {
                Mysql.CloseConn();
        
            }
            return Id;
        }



        public int UpdateNuReports(string CodeName)
        {
            int Id = -1;
            try
            {
               
                MySqlConnection conn = Mysql.GetConnnection();
                var Query = new MySqlCommand(@"UPDATE people SET num_reports = num_reports+1 WHERE secret_code =@CodeName  ", conn);
                Query.Parameters.AddWithValue("@CodeName", CodeName);
                Query.ExecuteNonQuery();

                ReturnId(CodeName);
            }
            
            
            catch (Exception ex)
            {
                Console.WriteLine("error" + ex.Message);
                
                
            }

            finally
            {
                Mysql.CloseConn();
                
            }
            return Id;

        }




        public int UpdateNumMentions(string CodeName)
        {
            int Id = -1;
            try
            {

                MySqlConnection conn = Mysql.GetConnnection();
                var Query = new MySqlCommand(@"UPDATE people SET num_reports = num_reports+1 WHERE secret_code =@CodeName  ", conn);
                Query.Parameters.AddWithValue("@CodeName", CodeName);
                Query.ExecuteNonQuery();

                ReturnId(CodeName);
            }


            catch (Exception ex)
            {
                Console.WriteLine("error" + ex.Message);


            }

            finally
            {
                Mysql.CloseConn();

            }
            return Id;

        }





        public int ReturnId(string codeName)
        {
            int Id = -1;
            try
            {

                MySqlConnection conn = Mysql.GetConnnection();
                var Cmd = new MySqlCommand(@"SELECT id FROM people WHERE secret_code  = @CodeName", conn);
                Cmd.Parameters.AddWithValue("@CodeName", codeName);
                var ReaderId = Cmd.ExecuteReader();
                if (ReaderId.Read())
                {
                    Id = ReaderId.GetInt32("id");
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("error" + ex.Message);


            }

            finally
            {
                Mysql.CloseConn();

            }
            return Id;
        }


    }
}

//public void NameSearch(string CodeName) //חיפוש שם
//{
//    MySqlConnection conn = Mysql.GetConnnection();

//    if (!ExaminationName(CodeName))
//    {
//        Console.WriteLine("The code name is not found");
//    }
//    try
//    {
//        var Query = new MySqlCommand("SELECT secret_code FROM people", conn);
//        var reader = Query.ExecuteReader();

//        while (reader.Read())
//        {
//            if (reader.GetString("secret_code") == CodeName)
//            {
//                List<string> list = new List<string>();
//                list.Add();
//            }

