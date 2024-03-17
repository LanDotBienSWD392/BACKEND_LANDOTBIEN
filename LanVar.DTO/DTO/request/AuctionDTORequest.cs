using LanVar.Core.Entity;
using System.ComponentModel.DataAnnotations;

namespace LanVar.DTO.DTO.request;

public class AuctionDTORequest
{
    
    public long Product_id { get; set; }

    [Required(ErrorMessage = "Start Day is required")]
    public DateTime StartDay { get; set; }

    [Required(ErrorMessage = "Auction Day is required")]
    public DateTime AuctionDay { get; set; }

    public string Auction_Name { get; set; }

    [Required(ErrorMessage = "Deposit Money is required")]
    public double Deposit_Money { get; set; }

    public bool Status { get; set; }

}
