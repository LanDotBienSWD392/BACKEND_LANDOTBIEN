using LanVar.Core.Entity;
using System.ComponentModel.DataAnnotations;
using Tools.Tools;

namespace LanVar.DTO.DTO.request;

public class AuctionDTORequest
{
    
    public long Product_id { get; set; }

    [Required(ErrorMessage = "Start Day is required")]
    public DateTime StartDay { get; set; }

    [Required(ErrorMessage = "Auction Day is required")]
    public DateTime AuctionDay { get; set; }

    [StringLength(maximumLength: 40, MinimumLength = 4)]
    public string Auction_Name { get; set; }
    

    [Required(ErrorMessage = "Deposit Money is required"), CustomDataValidation.IntRangeValidation(1000000, 1000000000)]
    public double Deposit_Money { get; set; }

    public String Status { get; set; }

    [Required(ErrorMessage = "Deposit Money is required")]
    public string Password { get; set; }

}
