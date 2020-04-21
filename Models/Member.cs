using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace LindyCircleMVC.Models
{
    public class Member
    {
        public int MemberID { get; set; }
        [Required, Display(Name = "First Name"), MaxLength(50)]
        public string FirstName { get; set; }
        [Required, Display(Name = "Last Name"), MaxLength(50)]
        public string LastName { get; set; }
        public bool Inactive { get; set; }
        [Display(Name = "Status")]
        public string ActiveText { get { return Inactive ? "Inactive" : "Active"; } }
        [Display(Name = "Name")]
        public string FirstLastName { get { return FirstName + " " + LastName; } }
        [Display(Name = "Name")]
        public string LastFirstName { get { return LastName + ", " + FirstName; } }
        [Display(Name = "Remaining Punches")]
        public int RemainingPunches {
            get {
                if (PunchCardsHeld == null) return 0;
                else return PunchCardsHeld.Sum(t => t.RemainingPunches);
            }
        }
        [Display(Name = "Total Paid"), DisplayFormat(DataFormatString = "{0:#0.00}")]
        public decimal TotalPaid {
            get {
                var attendances = 0M;
                var punchCards = 0M;
                if (Attendances != null)
                    attendances = Attendances.Sum(t => t.PaymentAmount);
                if (PunchCardsPurchased != null)
                    punchCards = PunchCardsPurchased.Sum(t => t.PurchaseAmount);
                return attendances + punchCards;
            }
        }
        [Display(Name = "Attended")]
        public int TotalAttendance {
            get {
                if (Attendances == null) return 0;
                else return Attendances.Count;
            }
        }

        public ICollection<Attendance> Attendances { get; set; }
        public ICollection<PunchCard> PunchCardsHeld { get; set; }
        public ICollection<PunchCard> PunchCardsPurchased { get; set; }
    }
}
