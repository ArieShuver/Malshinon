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
        int Report_id { get; set; }
        int Target_id { get; set; }
        string Text { get; set; }
        DateTime Timestamp { get; set; }
        public ReportModel(int report_id,int target_id,string text)
        {
            Report_id = report_id;
            Target_id = target_id;
            Text = text;
        }
    }
}
