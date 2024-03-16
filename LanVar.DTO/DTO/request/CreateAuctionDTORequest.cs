using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanVar.DTO.DTO.request
{
    public class CreateAuctionDTORequest
    {
        [StringLength(maximumLength: 40, MinimumLength = 8)]
        public required string Auction_Name { get; set; }
        public required double Deposit_Money { get; set; }
    }
}
