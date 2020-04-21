using System;
using System.Collections.Generic;

namespace LindyCircleMVC.Models
{
    public interface IPracticeRepository
    {
        IEnumerable<Practice> AllPractices { get; }
        Practice GetPractice(int practiceID);
        Practice GetPracticeByDate(DateTime practiceDate);
        IEnumerable<Practice> SearchPractices(DateTime? startDate, DateTime? endDate);
        Practice AddPractice(Practice practice);
        Practice UpdatePractice(Practice practice);
        void DeletePractice(Practice practice);
        int GetNextPracticeNumber();
        bool PracticeExists(int practiceID);
        bool HasParticipants(Practice practice);
    }
}
