using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanVar.Core.Entity
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public long id { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required]
        public long user_id { get; set; }

        [Required]
        public string product_Name { get; set; }

        [Required]
        public string product_Description { get; set; }

        public string image { get; set; }

        [Required]
        public double product_Price { get; set; }

        [Required]
        public string type { get; set; }

        [Required]
        public bool status { get; set; }

        [ForeignKey("user_id")]
        public User user { get; set; }
    }
}
