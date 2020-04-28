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

        public IEnumerable<PunchCard> AllPunchCards =>
            _dbContext.PunchCards
                .Include(i => i.PunchCardUsages)
                    .ThenInclude(i => i.Attendance)
                .Include(i => i.PurchaseMember)
                .Include(i => i.CurrentMember);

        public PunchCard GetPunchCard(int punchCardID) =>
            _dbContext.PunchCards
                .Include(i => i.PunchCardUsages)
                    .ThenInclude(i => i.Attendance)
                .Include(i => i.PurchaseMember)
                .Include(i => i.CurrentMember)
                .FirstOrDefault(p => p.PunchCardID == punchCardID);

        public IEnumerable<PunchCard> GetPunchCardsByMember(int memberID) =>
            _dbContext.PunchCards
                .Include(i => i.PunchCardUsages)
                    .ThenInclude(i => i.Attendance)
                .Include(i => i.PurchaseMember)
                .Include(i => i.CurrentMember)
                .Where(p => p.CurrentMemberID == memberID || p.PurchaseMemberID == memberID);

        public PunchCard GetUsablePunchCard(int memberID) {
            var punchCards = _dbContext.PunchCards
                .Include(i => i.PunchCardUsages)
                .Where(p => p.CurrentMemberID == memberID).AsEnumerable();

            return punchCards.Where(p => p.RemainingPunches > 0)
                .OrderBy(o => o.RemainingPunches)
                .First();
        }

        public PunchCard PurchasePunchCard(PunchCard punchCard) {
            punchCard.CurrentMemberID = punchCard.PurchaseMemberID;
            _dbContext.PunchCards.Add(punchCard);
            _dbContext.SaveChanges();
            return punchCard;
        }

        public PunchCard TransferPunchCard(PunchCard punchCard) {
            _dbContext.Attach(punchCard).State = EntityState.Modified;
            try {
                _dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException) {
                if (!PunchCardExists(punchCard.PunchCardID))
                    return null;
                else throw;
            }
            return punchCard;
        }

        public void DeletePunchCard(PunchCard punchCard) {
            if (PunchCardExists(punchCard.PunchCardID) &&
                punchCard.RemainingPunches == 5) {
                _dbContext.PunchCards.Remove(punchCard);
                _dbContext.SaveChanges();
            }
        }

        public void DeletePunchCard(int punchCardID) {
            var punchCard = _dbContext.PunchCards.Find(punchCardID);
            if (PunchCardExists(punchCardID) &&
                punchCard.RemainingPunches == 5) {
                _dbContext.PunchCards.Remove(punchCard);
                _dbContext.SaveChanges();
            }
        }

        private bool PunchCardExists(int punchCardID) => _dbContext.PunchCards.Find(punchCardID) != null;
    }
}
