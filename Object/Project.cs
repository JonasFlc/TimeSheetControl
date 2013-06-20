using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace TimeSheetControl.Object
{
    public class Project
    {
        public Decimal number { get; set; }
        public String name { get; set; }
        public IList<Task> tasks { get; set; }
        public String projectName {
            get{
                return this.number + " - " + this.name;
            }
        }   

        public String GetProjectName() {
            return this.number+ "-"+this.name;
        }

     }
}
