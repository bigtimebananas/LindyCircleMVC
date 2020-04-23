using LindyCircleMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LindyCircleMVC.ViewModels
{
    public class FinancesIndexViewModel
    {
        public IList<Practice> Practices { get; set; }
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
    }
}
