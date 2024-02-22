using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BACKEND.Models
{
    [Table("Bill")]
    public class Bill
    {
        [Key]
        public long id { get; set; }

        [Required]
        public long Order_id { get; set; }

        [Required]
        public string Payment_Method { get; set; }

        [Required]
        public double Total_Price { get; set; }

        [ForeignKey("Order_id")]
        public Order Order { get; set; }
    }
}
