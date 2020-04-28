using Microsoft.EntityFrameworkCore;
using System;
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
            _dbContext.Attendances
                .Include(i => i.Practice);

        public IEnumerable<Attendance> GetAttendancesByMember(int memberID) =>
            _dbContext.Attendances
                .Include(i => i.Practice)
                .Where(a => a.MemberID == memberID)
                .OrderBy(o => o.Practice.PracticeDate);

        public IEnumerable<Attendance> GetAttendancesByPractice(int practiceID) =>
            _dbContext.Attendances
                .Include(i => i.Member)
                .Where(a => a.PracticeID == practiceID)
                .OrderBy(o => o.Member.LastName)
                    .ThenBy(o => o.Member.FirstName);

        public Attendance GetAttendance(int attendanceID) =>
            _dbContext.Attendances.FirstOrDefault(a => a.AttendanceID == attendanceID);

        public Attendance AddAttendance(Attendance attendance) {
            _dbContext.Attendances.Add(attendance);
            _dbContext.SaveChanges();
            return attendance;
        }

        public Attendance AddAttendance(Attendance attendance, PunchCard punchCard) {
            _dbContext.Attendances.Add(attendance);
            _dbContext.SaveChanges();
            _dbContext.PunchCardUsages.Add(new PunchCardUsage
            {
                AttendanceID = attendance.AttendanceID,
                PunchCardID = punchCard.PunchCardID
            });
            _dbContext.SaveChanges();
            return attendance;
        }

        public void DeleteAttendance(Attendance attendance) {
            if (AttendanceExists(attendance.AttendanceID)) {
                var punchCardUsage = _dbContext.PunchCardUsages.FirstOrDefault(p => p.AttendanceID == attendance.AttendanceID);
                if (punchCardUsage != null) {
                    _dbContext.PunchCardUsages.Remove(punchCardUsage);
                    _dbContext.SaveChanges();
                }
                _dbContext.Remove(attendance);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteAttendance(int attendanceID) {
            if (AttendanceExists(attendanceID)) {
                var attendance = _dbContext.Attendances.Find(attendanceID);
                _dbContext.Remove(attendance);
                _dbContext.SaveChanges();
            }
        }

        private bool AttendanceExists(int attendanceID) => _dbContext.Attendances.Find(attendanceID) != null;
    }
}
