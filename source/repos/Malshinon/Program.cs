using Malshinon.models;
using System;
namespace DataBase

{
    public class Program
    {
        static void Main(string[] args)
        {
            MysqlData x = new MysqlData();
            x.GetConnnection();
            DalPepole d = new DalPepole(x);
            //d.CodeGeneration("fff");
            d.Report("dsd","reporter");

        }
    }
}
