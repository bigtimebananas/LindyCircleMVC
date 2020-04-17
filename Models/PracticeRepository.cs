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
                .Include(i => i.Attendances)
                .OrderBy(o => o.PracticeDate);

        public Practice GetPracticeByDate(DateTime practiceDate) =>
            _dbContext.Practices.FirstOrDefault(p => p.PracticeDate == practiceDate);

        public IEnumerable<Practice> SearchPractices(DateTime? startDate, DateTime? endDate, string topic) {
            var practices = AllPractices;
            if (startDate != null)
                practices = practices.Where(p => p.PracticeDate >= startDate.Value);
            if (endDate != null)
                practices = practices.Where(p => p.PracticeDate <= endDate.Value);
            if (!string.IsNullOrEmpty(topic))
                practices = practices.Where(p => p.PracticeTopic.Contains(topic));
            return practices;
        }
    }
}
