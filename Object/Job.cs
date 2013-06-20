using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeSheetControl.Object
{
    public class Job
    {
        public Decimal number { get; set; }
        public String name { get; set; }
        public Task task { get; set; }
        public Lazy<IList<Sheet>> sheets { get; set; }

        public String jobName
        {
            get
            {
                return this.number + " - " + this.name;
            }
        }   
    }
}
