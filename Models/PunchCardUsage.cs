using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LindyCircleMVC.Models
{
    public class PunchCardUsage
    {
        public int UsageId { get; set; }
        public int AttendanceId { get; set; }
        public int PunchCardId { get; set; }

        public virtual Attendance Attendance { get; set; }
        public virtual PunchCard PunchCard { get; set; }
    }
}
