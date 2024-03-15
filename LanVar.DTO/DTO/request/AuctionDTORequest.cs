using LanVar.Core.Entity;
using System.ComponentModel.DataAnnotations;

namespace LanVar.DTO.DTO.request;

public class AuctionDTORequest
{
    
    public long product_id { get; set; }

    [Required(ErrorMessage = "Start Day is required")]
    public DateTime startDay { get; set; }

    [Required(ErrorMessage = "Auction Day is required")]
    public DateTime auctionDay { get; set; }

    [Required(ErrorMessage = "Auction Name is required")]
    public required string auctionName { get; set; }

    [Required(ErrorMessage = "Deposit Money is required")]
    public double depositMoney { get; set; }

    public bool status { get; set; }

}
