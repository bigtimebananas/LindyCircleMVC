using System.Collections.Generic;
using System.Linq;

namespace LindyCircleMVC.Models
{
    public class PunchCardUsageRepository : IPunchCardUsageRepository
    {
        private readonly LindyCircleDbContext _dbContext;
        public PunchCardUsageRepository(LindyCircleDbContext dbContext) {
            _dbContext = dbContext;
        }

        public PunchCardUsage AddPunchCardUsage(int punchCardID, int attendanceID) {
            if (PunchCardExists(punchCardID) && AttendanceExists(attendanceID)) {
                var usage = new PunchCardUsage
                {
                    PunchCardID = punchCardID,
                    AttendanceID = attendanceID
                };
                _dbContext.PunchCardUsages.Add(usage);
                _dbContext.SaveChanges();
                return usage;
            }
            return null;
        }

        public void DeletePunchCardUsage(int punchCardUsageID) {
            if (PunchCardUsageExists(punchCardUsageID)) {
                var usage = _dbContext.PunchCardUsages.Find(punchCardUsageID);
                _dbContext.Remove(usage);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<PunchCardUsage> GetPunchCardUsageByPunchCard(int punchCardID) =>
            _dbContext.PunchCardUsages.Where(p => p.PunchCardID == punchCardID);

        private bool PunchCardExists(int punchCardID) => _dbContext.PunchCards.Find(punchCardID) != null;

        private bool AttendanceExists(int attendanceID) => _dbContext.Attendances.Find(attendanceID) != null;

        private bool PunchCardUsageExists(int punchCardUsageID) => _dbContext.PunchCardUsages.Find(punchCardUsageID) != null;
    }
}
