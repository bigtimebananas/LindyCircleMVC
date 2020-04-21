using LindyCircleMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LindyCircleMVC.ViewModels
{
    public class PracticeListViewModel
    {
        public IList<Practice> Practices { get; set; }
        public string Message { get; set; }
        [Display(Name = "Start Date"), DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }
        [Display(Name = "End Date"), DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
    }
}
