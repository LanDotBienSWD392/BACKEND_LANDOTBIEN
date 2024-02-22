using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BACKEND.Models
{
    [Table("OrderItem")]
    public class OrderItem
    {
        [Key]
        public long id { get; set; }

        [Required]
        public long Order_id { get; set; }

        [Required]
        public long Product_id { get; set; }

        [ForeignKey("Order_id")]
        public Order Order { get; set; }

        [ForeignKey("Product_id")]
        public Product Product { get; set; }
    }
}
