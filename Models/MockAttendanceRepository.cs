using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LindyCircleMVC.Models
{
    public class MockAttendanceRepository : IAttendanceRepository
    {
        private List<Attendance> Attendances =>
            new List<Attendance> {
                new Attendance { AttendanceID = 1, MemberID = 1, PracticeID = 1, PaymentType = 1, PaymentAmount = 7M },
                new Attendance { AttendanceID = 2, MemberID = 2, PracticeID = 1, PaymentType = 1, PaymentAmount = 7M },
                new Attendance { AttendanceID = 3, MemberID = 3, PracticeID = 1, PaymentType = 2, PaymentAmount = 0M }
            };

        public Attendance GetAttendance(int attendanceID) {
            return Attendances.FirstOrDefault(a => a.AttendanceID == attendanceID);
        }

        public IEnumerable<Attendance> GetAttendancesByMember(int memberID) {
            return Attendances.Where(a => a.MemberID == memberID);
        }

        public IEnumerable<Attendance> GetAttendancesByPractice(int practiceID) {
            return Attendances.Where(a => a.PracticeID == practiceID);
        }
    }
}
