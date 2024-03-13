using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class SearchProductDTORequest
{
    [Required(ErrorMessage = "ISBN is required")]
    public string ISBN { get; set; }
    [Required(ErrorMessage = "Product_Name is required")]
    public string Product_Name { get; set; }
    [Required(ErrorMessage = "Product_Price is required")]
    public string Product_Price { get; set; }
}

