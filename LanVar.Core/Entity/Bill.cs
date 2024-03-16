﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanVar.Core.Entity
{
    [Table("Bill")]
    public class Bill
    {
        [Key]
        public long id { get; set; }

        [Required]
        public long Order_id { get; set; }

        public string Payment_Method { get; set; }

        public double Total_Price { get; set; }

        [ForeignKey("Order_id")]
        public Order Order { get; set; }
    }
}
