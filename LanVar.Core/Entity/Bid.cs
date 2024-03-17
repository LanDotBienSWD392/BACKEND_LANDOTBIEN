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
        public long auction_id { get; set; }

        [Required]
        public long user_id { get; set; }

        [Required]
        public double bid { get; set; }

        public DateTime bid_time { get; set; }

        [ForeignKey("Auction_id")]
        public Auction auction { get; set; }

        [ForeignKey("User_id")]
        public User user { get; set; }
    }
}
