using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanVar.Core.Entity
{
    [Table("Bill")]
    public class Bill
    {
        [Key]
        public long id { get; set; }

        [Required]
        public long order_id { get; set; }

        public string payment_Method { get; set; }

        public double total_Price { get; set; }

        [ForeignKey("order_id")]
        public Order order { get; set; }
    }
}
