using LindyCircleMVC.Models;
using System.Collections.Generic;

namespace LindyCircleMVC.ViewModels
{
    public class MembersListViewModel
    {
        public IEnumerable<Member> Members { get; set; }
        public bool ActiveOnly { get; set; }
        public string Message { get; set; }
        public Member NewMember { get;set; }
    }
}
