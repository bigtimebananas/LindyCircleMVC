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
                    .ThenInclude(i => i.Practice)
                .Include(i => i.PunchCardsHeld)
                    .ThenInclude(i => i.PunchCardUsages)
                .Include(i => i.PunchCardsPurchased)
                .FirstOrDefault(m => m.MemberID == memberID);

        public Member AddMember(Member member) {
            member.Inactive = false;
            _dbContext.Members.Add(member);
            _dbContext.SaveChanges();
            return member;
        }

        public Member UpdateMember(Member member) {
            _dbContext.Attach(member).State = EntityState.Modified;
            try {
                _dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException) {
                if (!MemberExists(member.MemberID))
                    return null;
                else throw;
            }
            return member;
        }

        public void DeleteMember(Member member) {
            if (MemberExists(member.MemberID)) {
                _dbContext.Members.Remove(member);
                _dbContext.SaveChanges();
            }
        }

        private bool MemberExists(int memberID) => _dbContext.Members.Find(memberID) != null;
    }
}
