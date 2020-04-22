using LindyCircleMVC.Models;
using System.Collections.Generic;

namespace LindyCircleMVC.ViewModels
{
    public class PunchCardListViewModel
    {
        public IList<PunchCard> PunchCards { get; set; }
        public Member SelectedMember { get; set; }
    }
}
