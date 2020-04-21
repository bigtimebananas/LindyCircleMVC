using LindyCircleMVC.Models;
using System.Collections.Generic;

namespace LindyCircleMVC.ViewModels
{
    public class MemberDetailsViewModel
    {
        public Member Member { get; set; }
        public IList<Attendance> Practices { get; set; }
        public IList<PunchCard> PunchCardsPurchased { get; set; }
    }
}
