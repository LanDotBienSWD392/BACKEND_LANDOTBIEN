namespace LanVar.DTO.DTO.response;

public class ProductDTOResponse
{
    public long id { get; set; }
    public string ISBN { get; set; }
    public string Product_Name { get; set; }
    public string Product_Description { get; set; }
    public string Image { get; set; }
    public double Product_Price { get; set; }
    public string Type { get; set; }
    public bool Status { get; set; }
}