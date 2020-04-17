using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LindyCircleMVC.Models
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly LindyCircleDbContext _dbContext;
        public AttendanceRepository(LindyCircleDbContext dbContext) {
            _dbContext = dbContext;
        }

        public IEnumerable<Attendance> GetAttendancesByMember(int memberID) =>
            _dbContext.Attendance
                .Include(i => i.Practice)
                .Include(i => i.PunchCardUsages)
                .Where(a => a.MemberID == memberID);

        public IEnumerable<Attendance> GetAttendancesByPractice(int practiceID) =>
            _dbContext.Attendance
                .Include(i => i.Member)
                .Include(i => i.PunchCardUsages)
                .Where(a => a.PracticeID == practiceID);

        public Attendance GetAttendance(int attendanceID) =>
            _dbContext.Attendance.FirstOrDefault(a => a.AttendanceID == attendanceID);
    }
}
