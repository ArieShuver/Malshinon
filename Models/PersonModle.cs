using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using static System.Net.Mime.MediaTypeNames;

namespace Malshinon.models
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
        public PersonModle(string firstName, string lastName, string secretCode)
        {
            Firstn_name = firstName;
            Last_name = lastName;
            Secret_code = secretCode;
            Type = null;

        }

        public int GetId()
        {
            return Id;
        }
        public string GetFirsteName()
        {
            return Firstn_name;
        }
        public string GetLastName()
        {
            return Last_name;
        }
        public int GetNumReports()
        {
            return Num_reports;

        }
        public int GetNuMentions()
        {
            return Num_mentions;
        }
    }
}

