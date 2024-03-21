using LanVar.Core.Entity;

namespace LanVar.DTO.DTO.response;

public class BillDTOResponse
{
    public string user_id  { get; set; }
    public DateTime date { get; set; }
    public double total_Price { get; set; }
    public bool status { get; set; }
    public string payment_Method { get; set; }
    public string paymentUrl { get; set; }
    
}