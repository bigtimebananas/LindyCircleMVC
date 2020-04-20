using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LindyCircleMVC.Models
{
    public class MemberRepository : IMemberRepository
    {
        private readonly LindyCircleDbContext _dbContext;
        public MemberRepository(LindyCircleDbContext dbContext) {
            _dbContext = dbContext;
        }

        public IEnumerable<Member> GetMembers(bool activeOnly) =>
            _dbContext.Members
                .Include(i => i.Attendances)
                .Include(i => i.PunchCardsHeld)
                    .ThenInclude(i => i.PunchCardUsages)
                .Include(i => i.PunchCardsPurchased)
                .Where(m => !m.Inactive || m.Inactive != activeOnly)
                .OrderBy(o => o.FirstName)
                    .ThenBy(o => o.LastName);

        public Member GetMember(int memberID) =>
            _dbContext.Members
                .Include(i => i.Attendances)
                .Include(i => i.PunchCardsHeld)
                        .ThenInclude(i => i.PunchCardUsages)
                .Include(i => i.PunchCardsPurchased)
                .FirstOrDefault(m => m.MemberID == memberID);
    }
}
