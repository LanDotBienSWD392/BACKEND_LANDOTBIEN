using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanVar.Core.Entity
{
    public enum AuctionStatus
    {
        ACTIVE,
        INACTIVE
    }

    [Table("Auction")]
    public class Auction
    {

        [Key]
        public long id { get; set; }

        [Required]
        public long Product_id { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public DateTime StartDay { get; set; } //ngay khoi tao Auction

        public DateTime EndDay { get; set; }

        [Required]
        public DateTime AuctionDay { get; set; } // ngay dau gia

        [Required]
        public string Auction_Name { get; set; }

        [Required]
        public double Deposit_Money { get; set; }

        [Required]
        public AuctionStatus Status { get; set; }

        [ForeignKey("Product_id")]
        public Product Product { get; set; }
    }
}
