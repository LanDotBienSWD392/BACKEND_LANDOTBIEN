using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanVar.Core.Entity
{
    [Table("Bid")]
    public class Bid
    {
        [Key]
        public long id { get; set; }

        [Required]
        public long Auction_id { get; set; }

        [Required]
        public long User_id { get; set; }

        [Required]
        public double BID { get; set; }

        public DateTime Bid_time { get; set; }

        [ForeignKey("Auction_id")]
        public Auction Auction { get; set; }

        [ForeignKey("User_id")]
        public User User { get; set; }
    }
}
