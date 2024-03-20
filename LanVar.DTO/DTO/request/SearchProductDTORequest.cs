using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class SearchProductDTORequest
{
    [Required(ErrorMessage = "ISBN không được để trống")]
    public string ISBN { get; set; }

    [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
    public string Product_Name { get; set; }

    [Required(ErrorMessage = "Giá sản phẩm không được để trống")]
    public double Product_Price { get; set; }
}

