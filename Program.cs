
using Malshinon.Menu;
using Malshinon.models;
using System;
namespace DataBase

{
    public class Program
    {
        static void Main(string[] args)
        {
            MysqlData x = new MysqlData();
            //x.GetConnnection();
            //DalPepole d = new DalPepole(x);
            //DalRepott c = new DalRepott(x);
            //d.CodeGeneration("fff");
            //d.UpdateNum_reports("d1346");
            Menu t = new Menu(x);
            t.ReportingAgent();
            
        }
    }
}
