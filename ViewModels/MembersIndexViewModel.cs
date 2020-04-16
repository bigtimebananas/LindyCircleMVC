using LindyCircleMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LindyCircleMVC.ViewModels
{
    public class MembersIndexViewModel
    {
        public IEnumerable<Member> Members { get; set; }
        public IEnumerable<Attendance> Attendances { get; set; }
        public string ActiveStatus { get; set; }

    }
}
