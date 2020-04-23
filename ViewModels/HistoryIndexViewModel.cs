using System;
using System.ComponentModel.DataAnnotations;

namespace LindyCircleMVC.ViewModels
{
    public class HistoryIndexViewModel
    {
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
    }
}
