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
        public long product_id { get; set; }
        
        [Required]
        public long user_id { get; set; }
        
        public bool isSelected { get; set; }
        
        public bool hidden { get; set; }
        
        [ForeignKey("user_id")]
        public User user { get; set; }

        [ForeignKey("product_id")]
        public Product product { get; set; }
    }
}
