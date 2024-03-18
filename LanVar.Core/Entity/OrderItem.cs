using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanVar.Core.Entity
{
    [Table("OrderItem")]
    public class OrderItem
    {
        [Key]
        public long id { get; set; }

        [Required]
        public long order_id { get; set; }

        [Required]
        public long product_id { get; set; }

        [ForeignKey("order_id")]
        public Order order { get; set; }

        [ForeignKey("product_id")]
        public Product product { get; set; }
    }
}
