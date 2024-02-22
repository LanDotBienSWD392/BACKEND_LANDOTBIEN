using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BACKEND.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public long id { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required]
        public long User_id { get; set; }

        [Required]
        public string Product_Name { get; set; }

        [Required]
        public string Product_Description { get; set; }

        public string Image { get; set; }

        [Required]
        public double Product_Price { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public bool Status { get; set; }

        [ForeignKey("User_id")]
        public User User { get; set; }
    }
}
