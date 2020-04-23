using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LindyCircleMVC.Models
{
    public class PracticeRepository : IPracticeRepository
    {
        private readonly LindyCircleDbContext _dbContext;
        public PracticeRepository(LindyCircleDbContext dbContext) {
            _dbContext = dbContext;
        }

        public IEnumerable<Practice> AllPractices =>
            _dbContext.Practices
                .Include(i => i.Attendances);

        public Practice GetPractice(int practiceID) {
            return _dbContext.Practices
                .Include(i => i.Attendances)
                    .ThenInclude(i => i.Member)
                .FirstOrDefault(p => p.PracticeID == practiceID);
        }

        public Practice GetPracticeByDate(DateTime practiceDate) =>
            _dbContext.Practices.FirstOrDefault(p => p.PracticeDate == practiceDate);

        public IEnumerable<Practice> SearchPractices(DateTime? startDate, DateTime? endDate) {
            var practices = AllPractices;
            if (startDate != null)
                practices = practices.Where(p => p.PracticeDate >= startDate.Value);
            if (endDate != null)
                practices = practices.Where(p => p.PracticeDate <= endDate.Value);
            return practices;
        }

        public Practice AddPractice(Practice practice) {
            _dbContext.Practices.Add(practice);
            _dbContext.SaveChanges();
            return practice;
        }

        public Practice UpdatePractice(Practice practice) {
            _dbContext.Attach(practice).State = EntityState.Modified;
            try {
                _dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException) {
                if (!PracticeExists(practice.PracticeID))
                    return null;
                else throw;
            }
            return practice;
        }

        public void DeletePractice(Practice practice) {
            if (PracticeExists(practice.PracticeID) &&
                !HasParticipants(practice)) {
                _dbContext.Practices.Remove(practice);
                _dbContext.SaveChanges();
            }
        }

        public int GetNextPracticeNumber() => _dbContext.Practices.Max(m => m.PracticeNumber) + 1;

        public bool PracticeExists(int practiceID) => _dbContext.Practices.Find(practiceID) != null;

        public bool HasParticipants(Practice practice) => practice.Attendances.Count() > 0;

        public bool PracticeNumberUsed(int practiceID, int practiceNumber) {
            if (_dbContext.Practices.FirstOrDefault(p => p.PracticeNumber == practiceNumber) == null)
                return false;
            var practice = GetPractice(practiceID);
            _dbContext.Entry<Practice>(practice).State = EntityState.Detached;
            return practice.PracticeNumber != practiceNumber;
        }
    }
}
