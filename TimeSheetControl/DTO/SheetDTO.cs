using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeSheetControl.DTO
{
    public class SheetDTO : IComparable<SheetDTO>
    {
        
        public String ProjectNum { get; set; }
        public String ProjectName { get; set; }
        public String TaskNum { get; set; }
        public String TaskName {get;set;}
        public String JobNum { get; set; }
        public String JobName { get; set; }
        public String Start { get; set; }
        public String End { get; set; }
        public String Duration { get; set; }
        public String Note { get; set; }

        public int CompareTo(SheetDTO other)
        {
            return TaskName.CompareTo(other.TaskName);
        }
    }
}
