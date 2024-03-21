using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Tools;

namespace LanVar.DTO.DTO.request;

public class BidDTORequest
{

    [Required(ErrorMessage = "Auction is required")]
    public long auction_id { get; set; }

    [Required(ErrorMessage = "User is required")]
    public long user_id { get; set; }

    [Required(ErrorMessage = "Bid is required"), CustomDataValidation.IntRangeValidation(0, 1000000000000)]
    public double bid { get; set; }

    public DateTime bid_time { get; set; }
}
