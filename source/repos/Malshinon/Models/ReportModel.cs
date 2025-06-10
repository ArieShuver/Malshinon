using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon.models
{
    public class ReportModel
    {
        int id { get; set; }
        int report_id { get; set; }
        int target_id { get; set; }
        string text { get; set; }
        DateTime timestamp { get; set; }
        public ReportModel() 
        {
        }
    }
}
