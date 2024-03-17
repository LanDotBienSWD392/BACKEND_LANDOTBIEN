using LanVar.Core.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LanVar.DTO.DTO.response;

public class AuctionDTOResponse
{

    public long Product_id { get; set; }

    public DateTime StartDay { get; set; }

    public DateTime AuctionDay { get; set; }

    public required string Auction_Name { get; set; }

    public double Deposit_Money { get; set; }

    public bool Status { get; set; }

}
