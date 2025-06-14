
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Malshinon.models;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;



namespace Malshinon.Menu
{
    public class Menu
    {
        public MysqlData MySql;

        public Menu(MysqlData mysql)
        {
            MySql = mysql;

        }


        public void Switch()
        {

            DalPepole dalPepole = new DalPepole(MySql);


            bool exit = true;
            while (exit)
            {
                Console.WriteLine("Select an action (enter a number from 1 to 5):\r\n\r\n1 Report an agent – Allows you to report a new or existing agent.\n2 Show all agents – Displays a complete list of all agents in the system.\n3 Show dangerous agents – Displays only the agents marked as dangerous.\n4 Add a new name – Adds a new person to the list of agents.\n5 Exit – Closes the program.\r\n\r\n");

                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case (1):

                        ReportingAgent();
                        break;
                    case (2):

                        dalPepole.GetAllAgent();
                        break;

                    case (3):
                        dalPepole.GetAllDangerous();
                        break;

                    case (4):
                        dalPepole.AddName();
                        break;

                    case (5):
                        exit = false;
                        break;
                }
            }
        }










        public void ReportingAgent()
        {
            DalRepott dalRepott = new DalRepott(MySql);


            Console.WriteLine("Enter Code Name");
            string CodeName = Console.ReadLine();
            Console.WriteLine("Enter EnemyCode");
            string EnemyCode = Console.ReadLine();
            Console.WriteLine("Enter Text");
            string Text = Console.ReadLine();




            int ReportId;
            int TargetId;
            DalPepole dalPepole = new DalPepole(MySql);
            if (dalPepole.FindeName(CodeName))
            {
                ReportId = dalPepole.ReturnId(CodeName);
                string typeReporter = dalPepole.CheckStatus(ReportId);
                dalPepole.ChangeStatus(typeReporter, "reporter", ReportId);
                dalPepole.ChangeRank(ReportId);


            }

            else

            {
                Console.WriteLine("The code name is not found");
                ReportId = dalPepole.AddName();
            }

            if (dalPepole.FindeName(EnemyCode))
            {
                TargetId = dalPepole.ReturnId(EnemyCode);

                string typeTargt = dalPepole.CheckStatus(ReportId);
                dalPepole.ChangeStatus(typeTargt, "target", TargetId);
                dalPepole.PrintDanger(TargetId);
            }

            else
            {
                Console.WriteLine("The code enemy is not found");
                TargetId = dalPepole.AddName("target");
            }

            dalRepott.EnteringInformation(ReportId, TargetId, Text);
            dalPepole.UpdateReports(ReportId);
            dalPepole.UpdateMentions(TargetId);
        }

    }
}
