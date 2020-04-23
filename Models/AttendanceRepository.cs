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

        public IEnumerable<Attendance> GetAllAttendances => 
            _dbContext.Attendance
                .Include(i => i.Practice);

        public IEnumerable<Attendance> GetAttendancesByMember(int memberID) =>
            _dbContext.Attendance
                .Include(i => i.Practice)
                .Where(a => a.MemberID == memberID)
                .OrderBy(o => o.Practice.PracticeDate);

        public IEnumerable<Attendance> GetAttendancesByPractice(int practiceID) =>
            _dbContext.Attendance
                .Include(i => i.Member)
                .Where(a => a.PracticeID == practiceID)
                .OrderBy(o => o.Member.LastName)
                    .ThenBy(o => o.Member.FirstName);

        public Attendance GetAttendance(int attendanceID) =>
            _dbContext.Attendance.FirstOrDefault(a => a.AttendanceID == attendanceID);
    }
}
