using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon.models
{
    public class ReportModel
    {
        private int id { get; set; }
        private int Report_id { get; set; }
        private int Target_id { get; set; }
        private string Text { get; set; }
        private DateTime Timestamp { get; set; }
        public ReportModel(int report_id, int target_id, string text)
        {
            Report_id = report_id;
            Target_id = target_id;
            Text = text;
        }
        public int GetId()
        {
            return id;
        }
        public int GetReportId()
        {
            return Report_id;
        }
        public string GetText()
        {
            return Text;
        }
        public DateTime GetTime()
        {
            return Timestamp;

        }
    }
}