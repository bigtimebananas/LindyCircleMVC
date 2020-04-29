﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LindyCircleMVC.Models
{
    public class Attendance
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AttendanceID { get; set; }
        public int MemberID { get; set; }
        public int PracticeID { get; set; }
        [Required]
        public int PaymentType { get; set; }
        [Display(Name = "Type")]
        public string PaymentTypeText =>
            PaymentType switch
            {
                0 => "None",
                1 => "Cash",
                2 => "Punch card",
                _ => "Other",
            };
        [Required, Display(Name = "Amount"), DisplayFormat(DataFormatString = "{0:#,##0.00}")]
        public decimal PaymentAmount { get; set; }

        public Member Member { get; set; }
        public Practice Practice { get; set; }
        public PunchCardUsage PunchCardUsage { get; set; }
    }
}
