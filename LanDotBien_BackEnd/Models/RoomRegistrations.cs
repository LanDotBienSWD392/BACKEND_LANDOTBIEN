﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BACKEND.Models
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

        [Required]
        public DateTime Register_time { get; set; }

        [ForeignKey("User_id")]
        public User User { get; set; }

        [ForeignKey("Auction_id")]
        public Auction Auction { get; set; }
    }
}
