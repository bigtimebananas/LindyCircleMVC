using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace LindyCircleMVC.ViewModels
{
    public class AttendanceMembersViewModel
    {
        public List<SelectListItem> Members;
        public int PracticeID;
    }
}
