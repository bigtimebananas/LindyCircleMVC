using System.Collections.Generic;

namespace LindyCircleMVC.Models
{
    public interface IAttendanceRepository
    {
        IEnumerable<Attendance> GetAllAttendances { get; }
        IEnumerable<Attendance> GetAttendancesByMember(int memberID);
        IEnumerable<Attendance> GetAttendancesByPractice(int practiceID);
        Attendance GetAttendance(int attendanceID);
        Attendance AddAttendance(Attendance attendance);
        void DeleteAttendance(Attendance attendance);
        void DeleteAttendance(int attendanceID);
    }
}
