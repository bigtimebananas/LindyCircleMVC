using System.Collections.Generic;

namespace LindyCircleMVC.Models
{
    public interface IPunchCardUsageRepository
    {
        IEnumerable<PunchCardUsage> GetPunchCardUsageByPunchCard(int punchCardID);
    }
}
