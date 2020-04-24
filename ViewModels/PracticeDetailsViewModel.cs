using LindyCircleMVC.Models;
using System;
using System.Collections.Generic;

namespace LindyCircleMVC.ViewModels
{
    public class PracticeDetailsViewModel
    {
        public Practice Practice { get; set; }
        public IList<Attendance> Attendances { get; set; }
        public DateTime PracticeDate { get; set; }
    }
}
