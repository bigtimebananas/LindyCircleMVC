using System;
using System.Collections.Generic;

namespace LindyCircleMVC.Models
{
    public interface IPracticeRepository
    {
        IEnumerable<Practice> AllPractices { get; }
        Practice GetPracticeByDate(DateTime practiceDate);
        IEnumerable<Practice> SearchPractices(DateTime? startDate, DateTime? endDate, string topic);
    }
}
