﻿using System.Collections.Generic;

namespace LindyCircleMVC.Models
{
    public interface IAttendanceRepository
    {
        IEnumerable<Attendance> GetAttendancesByMember(int memberID);
        IEnumerable<Attendance> GetAttendancesByPractice(int practiceID);
        Attendance GetAttendance(int attendanceID);
    }
}
