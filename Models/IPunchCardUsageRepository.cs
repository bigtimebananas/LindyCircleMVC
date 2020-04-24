using System.Collections.Generic;

namespace LindyCircleMVC.Models
{
    public interface IPunchCardUsageRepository
    {
        IEnumerable<PunchCardUsage> GetPunchCardUsageByPunchCard(int punchCardID);
        PunchCardUsage AddPunchCardUsage(int punchCardID, int attendanceID);
        void DeletePunchCardUsage(int punchCardUsageID);
    }
}
