using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanVar.DTO.DTO.response;

public class BidDTOResponse
{
    public long id { get; set; }

    public AuctionDTOResponse auction { get; set; }

    public UserDTOResponse user { get; set; }

    public double bid { get; set; }

    public DateTime bid_time { get; set; }
}
