using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanVar.DTO.DTO.request
{
    public class CreateOrderDTORequest
    {
        public int user_id { get; set; }
        public int orderItem_id { get; set; }
        public DateTime date { get; set; }
        public double total_Price { get; set; }
        public bool status { get; set; }
        public string orderCode { get; set; }

    }
}
