using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanVar.Core.Entity
{
    [Table("RoomRegistrations")]
    public class RoomRegistrations
    {
        [Key]
        public long id { get; set; }

        [Required]
        public long User_id { get; set; }

        [Required]
        public long Auction_id { get; set; }

        public DateTime Register_time { get; set; }

        [ForeignKey("User_id")]
        public User User { get; set; }

        [ForeignKey("Auction_id")]
        public Auction Auction { get; set; }
    }
}
