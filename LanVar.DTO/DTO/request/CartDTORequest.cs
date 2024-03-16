namespace LanVar.DTO.DTO.request;

public class CartDTORequest
{
    public long User_id { get; set; }
    public long Product_id { get; set; }
    public bool isSelected { get; set; }
}