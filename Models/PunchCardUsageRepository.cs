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

        public IEnumerable<PunchCardUsage> GetPunchCardUsageByPunchCard(int punchCardID) =>
            _dbContext.PunchCardUsage.Where(p => p.PunchCardID == punchCardID);
    }
}
