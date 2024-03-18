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
        public long user_id { get; set; }

        [Required]
        public long auction_id { get; set; }

        public DateTime register_time { get; set; }

        [ForeignKey("user_id")]
        public User user { get; set; }

        [ForeignKey("auction_id")]
        public Auction auction { get; set; }
    }
}
