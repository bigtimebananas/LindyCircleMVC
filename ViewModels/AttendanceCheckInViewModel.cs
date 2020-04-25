using LindyCircleMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace LindyCircleMVC.ViewModels
{
    public class AttendanceCheckInViewModel
    {
        public Practice Practice { get; set; }
        public IList<Attendance> Attendances { get; set; }
        public IList<SelectListItem> Members { get; set; }
        public List<SelectListItem> PaymentMethods { get; set; }
        public decimal AdmissionCost { get; set; }

    }
}
