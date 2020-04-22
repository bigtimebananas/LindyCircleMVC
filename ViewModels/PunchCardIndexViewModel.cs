using LindyCircleMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace LindyCircleMVC.ViewModels
{
    public class PunchCardIndexViewModel
    {
        public IList<SelectListItem> Members { get; set; }
        public PunchCard NewPunchCard { get; set; }
        public string SelectedMemberID { get; set; }
    }
}
