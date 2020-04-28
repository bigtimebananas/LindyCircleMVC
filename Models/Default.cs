using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LindyCircleMVC.Models
{
    public class Default
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DefaultID { get; set; }
        public string DefaultName { get; set; }
        public decimal DefaultValue { get; set; }
    }
}
