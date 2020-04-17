﻿namespace LindyCircleMVC.Models
{
    public class PunchCardUsage
    {
        public int UsageID { get; set; }
        public int AttendanceID { get; set; }
        public int PunchCardID { get; set; }

        public virtual Attendance Attendance { get; set; }
        public virtual PunchCard PunchCard { get; set; }
    }
}
