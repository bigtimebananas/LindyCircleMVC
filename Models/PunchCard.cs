using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LindyCircleMVC.Models
{
    public class PunchCard
    {
        public int PunchCardID { get; set; }
        public int PurchaseMemberID { get; set; }
        public int CurrentMemberID { get; set; }
        [Required, Display(Name = "Purchase Date"), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime PurchaseDate { get; set; }
        [Required, Display(Name = "Amount"), DisplayFormat(DataFormatString = "{0:#0.00}")]
        public decimal PurchaseAmount { get; set; }
        [Display(Name = "Remaining Punches")]
        public int RemainingPunches { get { return 5 - PunchCardUsages.Count; } }

        public Member CurrentMember { get; set; }
        public Member PurchaseMember { get; set; }
        public ICollection<PunchCardUsage> PunchCardUsages { get; set; }
    }
}
