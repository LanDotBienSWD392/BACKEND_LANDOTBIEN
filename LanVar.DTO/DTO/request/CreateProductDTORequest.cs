using System.ComponentModel.DataAnnotations;

namespace LanVar.DTO.DTO.request;

public class CreateProductDTORequest
{
    [Required(ErrorMessage = "ISBN is required")]
    public string ISBN { get; set; }
    public long User_id { get; set; }
    [Required(ErrorMessage = "Product Name is required")]
    public string Product_Name { get; set; }
    [Required(ErrorMessage = "Product Description is required")]
    public string Product_Description { get; set; }
    [Required(ErrorMessage = "Image is required")]
    public string Image { get; set; }
    [Required(ErrorMessage = "Product Price is required")]
    public double Product_Price { get; set; }
    [Required(ErrorMessage = "Type is required")]
    public string Type { get; set; }
    public bool Status { get; set; }
}