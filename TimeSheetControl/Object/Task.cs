using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeSheetControl.Object
{
    public class Task
    {
        public Decimal number { get; set; }
        public String name { get; set; }
        public Project project { get; set; }
        public IList<Job> jobs { get; set; }

        public String GetTaskFullName()
        {
            return this.project.GetProjectName() + " / " + this.number + "-" + this.name;
        }

        public String taskName
        {
            get
            {
                return this.number + " - " + this.name;
            }
        }   
    }
}
