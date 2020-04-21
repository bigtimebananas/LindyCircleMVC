using System.ComponentModel.DataAnnotations;

namespace LindyCircleMVC.Models
{
    public class Attendance
    {
        public int AttendanceID { get; set; }
        public int MemberID { get; set; }
        public int PracticeID { get; set; }
        [Required]
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
        [Required, Display(Name = "Amount"), DisplayFormat(DataFormatString = "{0:#,##0.00}")]
        public decimal PaymentAmount { get; set; }

        public Member Member { get; set; }
        public Practice Practice { get; set; }
        public PunchCardUsage PunchCardUsage { get; set; }
    }
}
