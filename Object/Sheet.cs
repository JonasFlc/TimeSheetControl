using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeSheetControl.Object
{
    public class Sheet
    {
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public String note { get; set; }
        public Job job { get; set; }

        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            Sheet p = obj as Sheet;
            if ((System.Object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (start == p.start) && (end == p.end) && (job.number == p.job.number);
        }

        public bool Equals(Sheet p)
        {
            // If parameter is null return false:
            if ((object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (start == p.start) && (end == p.end) && (job.number == p.job.number);
        }

        public override int GetHashCode()
        {
            return start.GetHashCode() ^ end.GetHashCode() ^ job.number.GetHashCode();
        }

        //
        public static bool operator ==(Sheet a, Sheet b)
        {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            // Return true if the fields match:
            return (a.start == b.start) && (a.end == b.end) && (a.job.number == b.job.number);
        }

        public static bool operator !=(Sheet a, Sheet b)
        {
            return !(a == b);
        }
    }
}
