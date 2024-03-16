using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanVar.Core.Entity
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public long id { get; set; }

        [Required]
        public long User_id { get; set; }

        public DateTime Date { get; set; }

        public double Total_Price { get; set; }
        
        public string Status { get; set; } // Confirmed - In Transit - Delivered - Canceled

        [ForeignKey("User_id")]
        public User User { get; set; }
    }
}
