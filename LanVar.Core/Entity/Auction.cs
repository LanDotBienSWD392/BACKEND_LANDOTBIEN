using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanVar.Core.Entity
{
    public enum AuctionStatus
    {
        ACTIVE,
        INACTIVE,
        WAITING
    }

    [Table("Auction")]
    public class Auction
    {

        [Key]
        public long id { get; set; }

        [Required]
        public long product_id { get; set; }

        [Required]
        public string password { get; set; }

        [Required]
        public DateTime startDay { get; set; } //ngay khoi tao Auction

        public DateTime endDay { get; set; }

        [Required]
        public DateTime auctionDay { get; set; } // ngay dau gia

        [Required]
        public string auction_Name { get; set; }

        [Required]
        public double deposit_Money { get; set; }

        [Required]
        public AuctionStatus status { get; set; }

        [ForeignKey("product_id")]
        public Product product { get; set; }
    }
}
