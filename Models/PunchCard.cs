using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LindyCircleMVC.Models
{
    public class PunchCard
    {
        public int PunchCardID { get; set; }
        public int PurchaseMemberID { get; set; }
        public int CurrentMemberID { get; set; }
        [Display(Name = "Purchase Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime PurchaseDate { get; set; }
        [Display(Name = "Amount")]
        public decimal PurchaseAmount { get; set; }
        public int RemainingPunches { get { return 5 - PunchCardUsages.Count; } }

        public Member CurrentMember { get; set; }
        public Member PurchaseMember { get; set; }
        public ICollection<PunchCardUsage> PunchCardUsages { get; set; }
    }
}
