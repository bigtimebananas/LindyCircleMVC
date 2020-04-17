using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LindyCircleMVC.Models
{
    public class PunchCardRepository : IPunchCardRepository
    {
        private readonly LindyCircleDbContext _dbContext;
        public PunchCardRepository(LindyCircleDbContext dbContext) {
            _dbContext = dbContext;
        }
        public PunchCard GetPunchCard(int punchCardID) =>
            _dbContext.PunchCards
                .Include(i => i.PunchCardUsages)
                    .ThenInclude(i => i.Attendance)
                        .ThenInclude(i => i.Practice)
                .FirstOrDefault(p => p.PunchCardID == punchCardID);

        public IEnumerable<PunchCard> GetPunchCardsHeldByMember(int memberID) =>
            _dbContext.PunchCards
                .Include(i => i.PunchCardUsages)
                    .ThenInclude(i => i.Attendance)
                        .ThenInclude(i => i.Practice)
                .Where(p => p.CurrentMemberID == memberID);

        public IEnumerable<PunchCard> GetPunchCardsPurchasedByMember(int memberID) =>
            _dbContext.PunchCards
                .Include(i => i.PunchCardUsages)
                    .ThenInclude(i => i.Attendance)
                        .ThenInclude(i => i.Practice)
                .Where(p => p.PurchaseMemberID == memberID);
    }
}
