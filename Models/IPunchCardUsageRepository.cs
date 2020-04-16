using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LindyCircleMVC.Models
{
    public interface IPunchCardUsageRepository
    {
        PunchCardUsage GetPunchCardUsageByAttendance(int attendanceID);
        PunchCardUsage GetPunchCardUsageByPunchCard(int punchCardID);
    }
}
