using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LindyCircleMVC.Models
{
    public interface IAttendanceRepository
    {
        IEnumerable<Attendance> AllAttendances { get; }
        IEnumerable<Attendance> GetAttendancesByMember(int memberID);
        IEnumerable<Attendance> GetAttendancesByPractice(int practiceID);
        Attendance GetAttendance(int attendanceID);
    }
}
