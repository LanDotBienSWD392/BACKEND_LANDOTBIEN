namespace LanVar.DTO.DTO.request;

public class OrderItemDTORequest
{
    public long product_id { get; set; }
    public long user_id { get; set; }
    public bool isSelected { get; set; }
}