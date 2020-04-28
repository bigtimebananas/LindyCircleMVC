using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LindyCircleMVC.Models
{
    public class PunchCardUsage
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UsageID { get; set; }
        public int AttendanceID { get; set; }
        public int PunchCardID { get; set; }

        public virtual Attendance Attendance { get; set; }
        public virtual PunchCard PunchCard { get; set; }
    }
}
