using System;
using System.ComponentModel.DataAnnotations;

namespace LindyCircleMVC.ViewModels
{
    public class AttendanceIndexViewModel
    {
        [DataType(DataType.Date), Required, Display(Name = "Practice Date")]
        public DateTime PracticeDate { get; set; }
    }
}
