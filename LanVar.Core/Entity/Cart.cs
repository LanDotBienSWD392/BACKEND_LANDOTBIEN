using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LanVar.Core.Entity
{
    [Table("Cart")]
    public class Cart
    {
        [Key]
        public long id { get; set; }

        [Required]
        public long User_id { get; set; }

        [Required]
        public long Product_id { get; set; }

        [Required]
        public bool isSelected { get; set; }

        [ForeignKey("User_id")]
        public User User { get; set; }

        [ForeignKey("Product_id")]
        public Product Product { get; set; }
    }
}
