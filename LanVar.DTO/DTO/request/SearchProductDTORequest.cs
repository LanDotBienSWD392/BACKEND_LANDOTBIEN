using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class SearchProductDTORequest
{
   
    public string ISBN { get; set; }
    
    public string Product_Name { get; set; }
    
    public double Product_Price { get; set; }
}

