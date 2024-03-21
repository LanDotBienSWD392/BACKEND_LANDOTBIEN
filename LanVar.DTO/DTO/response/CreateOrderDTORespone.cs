using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanVar.DTO.DTO.response
{
    public class CreateOrderDTORespone
    {
        public long ID { get; set; }
        public required long UsertID { get; set; }
        public DateTime Date { get; set; }
        public double Total_Price { get; set; }
        public string orderCode { get; set; }
    }
}
