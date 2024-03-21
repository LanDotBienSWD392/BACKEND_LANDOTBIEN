using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanVar.Core.Entity
{
    public enum OrderStatus
    {
        Waiting,
        Confirmed,
        InTransit,
        Delivered,
        Canceled
    }
    [Table("Order")]
    public class Order
    {
        [Key]
        public long id { get; set; }

        [Required]
        public long user_id { get; set; }

        [Required]
        public long orderItem_id {  get; set; }

        public DateTime date { get; set; }

        public double total_Price { get; set; }
        
        public string orderCode { get; set; }
        public OrderStatus status { get; set; } // Confirmed - In Transit - Delivered - Canceled

        [ForeignKey("user_id")]
        public User user { get; set; }
    }
}
