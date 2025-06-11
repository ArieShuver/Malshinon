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
                Query.Parameters.AddWithValue("@CodeGeneration", CodeName);
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



        public void UpdateReports(int CodeName)
        {
            int Id = -1;
            try
            {

                MySqlConnection conn = Mysql.GetConnnection();
                var Query = new MySqlCommand(@"UPDATE people SET num_reports = num_reports+1 WHERE id =@CodeName  ", conn);
                Query.Parameters.AddWithValue("@CodeName", CodeName);
                Query.ExecuteNonQuery();

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
            //return Id;

        }




        public void UpdateMentions(int CodeName)
        {
            int Id = -1;
            try
            {

                MySqlConnection conn = Mysql.GetConnnection();
                var Query = new MySqlCommand(@"UPDATE people SET num_mentions = num_mentions+1 WHERE id =@CodeName  ", conn);
                Query.Parameters.AddWithValue("@CodeName", CodeName);
                Query.ExecuteNonQuery();

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
            //return Id;

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







        public string CheckStatus(int Id)
        {
            string Type = "";
            try
            {
                MySqlConnection conn = Mysql.GetConnnection();
                var Query = new MySqlCommand(@"SELECT type FROM people WHERE id = @Id", conn);
                Query.Parameters.AddWithValue("@id", Id);

                var raeder = Query.ExecuteReader();
                if (raeder.Read())
                {
                    Type = raeder.GetString("type");
                }
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
            return Type;
        }





        public void ChangeStatus(string type1, string type2, int id)
        {
            if (type1 != type2)
            {
                try
                {
                    MySqlConnection conn = Mysql.GetConnnection();
                    var Query = new MySqlCommand("UPDATE people SET type = 'both' WHERE id = @Id", conn);
                    Query.Parameters.AddWithValue("@id", id);
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
       public void ChangeRank(int id)
        {
            MySqlConnection conn = Mysql.GetConnnection();
            var Query = new MySqlCommand("SELECT num_reports FROM people WHERE id = @Id", conn);
            Query.Parameters.AddWithValue("@id", id);
            var reader = Query.ExecuteReader();
            if (reader.Read())
            {
                int numRepurt = reader.GetInt32("num_reports");
            if (numRepurt>10)
                {
                    Mysql.CloseConn();
                    MySqlConnection conn1 = Mysql.GetConnnection();

                    var cmd = new MySqlCommand("UPDATE people SET type = 'agent_candidate' WHERE id = @Id", conn1);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                   
                }
            }
        }
        public void PrintDanger(int id)
        {
            MySqlConnection conn = Mysql.GetConnnection();
            var Query = new MySqlCommand("SELECT num_mentions FROM people WHERE id = @id", conn);
            Query.Parameters.AddWithValue("@id", id);
            var reader = Query.ExecuteReader();
            if (reader.Read())
            {
                int numRepurt = reader.GetInt32("num_mentions");
                if (numRepurt > 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("danger");
                    Console.ForegroundColor = ConsoleColor.White;

                    Mysql.CloseConn();


                }
            }
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

