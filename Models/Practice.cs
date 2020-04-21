using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace LindyCircleMVC.Models
{
    public class Practice
    {
        public int PracticeID { get; set; }
        [Required, Display(Name = "Practice Date"), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime PracticeDate { get; set; }
        [Required, Display(Name = "Practice Number")]
        public int PracticeNumber { get; set; }
        [Required, Display(Name = "Rental Cost"), DisplayFormat(DataFormatString = "{0:#,##0.00}")]
        public decimal PracticeCost { get; set; }
        [Required, Display(Name = "Misc Expense"), DisplayFormat(DataFormatString = "{0:#,##0.00}")]
        public decimal MiscExpense { get; set; }
        [Required, Display(Name = "Misc Revenue"), DisplayFormat(DataFormatString = "{0:#,##0.00}")]
        public decimal MiscRevenue { get; set; }
        [Required, Display(Name = "Practice Topic"), MaxLength(255)]
        public string PracticeTopic { get; set; }
        [Display(Name = "Admission Revenue"), DisplayFormat(DataFormatString = "{0:#,##0.00}")]
        public decimal AttendanceRevenue {
            get {
                if (Attendances == null) return 0;
                else return Attendances.Sum(s => s.PaymentAmount);
            }
        }
        [Display(Name = "Attendees")]
        public int AttendeeCount {
            get {
                if (Attendances == null) return 0;
                else return Attendances.Count();
            }
        }

        public ICollection<Attendance> Attendances { get; set; }
    }
}
