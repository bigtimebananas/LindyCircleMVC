using Microsoft.AspNetCore.Mvc.Rendering;
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

        public IList<SelectListItem> GetMemberList() {
            var selectList = new List<SelectListItem>();
            foreach (var member in _dbContext.Members
                .OrderBy(o => o.FirstName)
                    .ThenBy(o => o.LastName))
                selectList.Add(new SelectListItem
                {
                    Value = member.MemberID.ToString(),
                    Text = member.FirstLastName
                });
            return selectList;
        }

        public IList<SelectListItem> GetTransferMemberList(int memberID) {
            var selectList = new List<SelectListItem>();
            foreach (var member in _dbContext.Members
                .Where(m => m.MemberID != memberID)
                .OrderBy(o => o.FirstName)
                    .ThenBy(o => o.LastName))
                selectList.Add(new SelectListItem
                {
                    Value = member.MemberID.ToString(),
                    Text = member.FirstLastName
                });
            return selectList;
        }

        public IList<SelectListItem> GetPracticeMemberList(int practiceID) {
            var selectList = new List<SelectListItem>();
            var query = from m in _dbContext.Members
                        where !m.Inactive && !(
                            from a in _dbContext.Attendance
                            select a.MemberID)
                            .Contains(m.MemberID)
                        select m;
            foreach (var member in query)
                selectList.Add(new SelectListItem
                {
                    Value = member.MemberID.ToString(),
                    Text = member.FirstLastName
                });
            return selectList;
        }

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
