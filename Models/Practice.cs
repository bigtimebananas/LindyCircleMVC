using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LindyCircleMVC.Models
{
    public class Practice
    {
        public int PracticeID { get; set; }
        [Required, Display(Name = "Practice Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime PracticeDate { get; set; }
        [Required, Display(Name = "Practice Number")]
        public int PracticeNumber { get; set; }
        [Required, Display(Name = "Practice Cost"), DisplayFormat(DataFormatString = "{0:#0.00}")]
        public decimal PracticeCost { get; set; }
        [Required, Display(Name = "Misc Expense"), DisplayFormat(DataFormatString = "{0:#0.00}")] 
        public decimal MiscExpense { get; set; }
        [Required, Display(Name = "Misc Revenue"), DisplayFormat(DataFormatString = "{0:#0.00}")] 
        public decimal MiscRevenue { get; set; }
        [Required, Display(Name = "Practice Tpoic"), MaxLength(255)] 
        public string PracticeTopic { get; set; }

        public ICollection<Attendance> Attendances { get; set; }
    }
}
