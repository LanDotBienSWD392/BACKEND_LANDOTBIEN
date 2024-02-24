using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanVar.Core.Entity
{
    [Table("Auction")]
    public class Auction
    {
        [Key]
        public long id { get; set; }

        [Required]
        public long Product_id { get; set; }

        [Required]
        public DateTime StartDay { get; set; }

        [Required]
        public DateTime AuctionDay { get; set; }

        [Required]
        public string Auction_Name { get; set; }

        [Required]
        public double Deposit_Money { get; set; }

        [Required]
        public bool Status { get; set; }

        [ForeignKey("Product_id")]
        public Product Product { get; set; }
    }
}
