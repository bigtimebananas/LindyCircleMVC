using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LindyCircleMVC.Models
{
    public class Practice
    {
        public int PracticeId { get; set; }
        [Required]
        [Display(Name = "Practice Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime PracticeDate { get; set; }
        public int PracticeNumber { get; set; }
        public decimal PracticeCost { get; set; }
        public decimal MiscExpense { get; set; }
        public decimal MiscRevenue { get; set; }
        public string PracticeTopic { get; set; }

        public ICollection<Attendance> Attendances { get; set; }
    }
}
