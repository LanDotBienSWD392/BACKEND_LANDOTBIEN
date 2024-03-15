using LanVar.Core.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LanVar.DTO.DTO.response;

public class AuctionDTOResponse
{

    public long product_id { get; set; }

    public DateTime startDay { get; set; }

    public DateTime auctionDay { get; set; }

    public required string auctionName { get; set; }

    public double depositMoney { get; set; }

    public bool status { get; set; }

    public required Product product { get; set; }
}
