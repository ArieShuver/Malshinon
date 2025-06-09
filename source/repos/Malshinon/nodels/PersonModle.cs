using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon.nodels
{
    public class PersonModle
    {
        int Id { get; set; }
        string Firstn_name { get; set; }
        string Last_name { get; set; }
        string Secret_code { get; set; }
        string Type { get; set; }
        int Num_reports { get; set; }
        int Num_mentions { get; set; }
        public PersonModle(string firstName,string lastName, string secretCode)
        {
            Firstn_name = firstName;
            Last_name = lastName;
            Secret_code = secretCode;
            Type = null;
            
        }
    }
}
