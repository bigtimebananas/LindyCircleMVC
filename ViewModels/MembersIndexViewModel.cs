using LindyCircleMVC.Models;
using System.Collections.Generic;

namespace LindyCircleMVC.ViewModels
{
    public class MembersIndexViewModel
    {
        public IEnumerable<Member> Members { get; set; }
        public string ActiveStatus { get; set; }

    }
}
