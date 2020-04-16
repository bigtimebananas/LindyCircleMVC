using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LindyCircleMVC.Models
{
    public class Attendance
    {
        public int AttendanceId { get; set; }
        public int MemberId { get; set; }
        public int PracticeId { get; set; }
        public int PaymentType { get; set; }
        [Display(Name = "Type")]
        public string PaymentTypeText {
            get {
                return PaymentType switch
                {
                    0 => "None",
                    1 => "Cash",
                    2 => "Punch card",
                    _ => "Other",
                };
            }
        }
        [Required]
        [Display(Name = "Amount")]
        public decimal PaymentAmount { get; set; }

        public Member Member { get; set; }
        public Practice Practice { get; set; }
        public ICollection<PunchCardUsage> PunchCardUsages { get; set; }
    }
}
