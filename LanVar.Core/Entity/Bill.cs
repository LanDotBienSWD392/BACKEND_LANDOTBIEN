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
        public long user_id { get; set; }

        public string payment_Method { get; set; }

        public double total_Price { get; set; }
        
        public bool status { get; set; }
        
        public string orderCode { get; set; }
        public string paymentUrl { get; set; }

        [ForeignKey("user_id")]
        public User user { get; set; }
    }
}
