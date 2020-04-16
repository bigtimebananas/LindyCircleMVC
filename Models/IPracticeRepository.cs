using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LindyCircleMVC.Models
{
    public interface IPracticeRepository
    {
        IEnumerable<Practice> AllPractices { get; }
        IEnumerable<Practice> GetPracticesByDate(DateTime? startDate, DateTime? endDate);
        IEnumerable<Practice> GetPracticesByTopic(string topic);
        IEnumerable<Practice> SearchPractices(DateTime? startDate, DateTime? endDate, string topic);
    }
}
