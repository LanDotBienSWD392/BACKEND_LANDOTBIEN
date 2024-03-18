using LanVar.Core.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LanVar.DTO.DTO.response;

public class AuctionDTOResponse
{
    public long id { get; set; }
    public ProductDTOResponse Product { get; set; }

    public DateTime StartDay { get; set; }

    public DateTime AuctionDay { get; set; }

    public string Auction_Name { get; set; }

    public double Deposit_Money { get; set; }

    public String Status { get; set; }

    public string Password { get; set; }
    /*public string ErrorMessage { get; set; }*/

}
