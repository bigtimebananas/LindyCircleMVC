using LindyCircleMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LindyCircleMVC.ViewModels
{
    public class AttendanceCheckInViewModel
    {
        public Practice Practice { get; set; }
        public Member Member { get; set; }
        public IList<Attendance> Attendances { get; set; }
        public List<SelectListItem> PaymentMethods { get; set; }
        public decimal AdmissionCost { get; set; }
        [Required]
        public decimal PaymentAmount { get; set; }
        public int PaymentType { get; set; }
    }
}
