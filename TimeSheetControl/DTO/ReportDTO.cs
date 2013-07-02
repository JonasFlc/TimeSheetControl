using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeSheetControl.Object;

namespace TimeSheetControl.DTO
{
    public class ReportDTO 
    {
        public Decimal id { get; set; }
        public Int32 level { get; set; }
        public String name { get; set; }
        public String totalTime { get; set; }

        public ReportDTO(Decimal id, String name, Int32 level, TimeSpan totalTime)
        {
            this.id = id;
            this.name = name;
            this.level = level;
            this.totalTime = totalTime.ToString(@"hh\:mm");

        }
       
    }
}
