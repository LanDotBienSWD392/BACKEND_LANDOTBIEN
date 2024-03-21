using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanVar.DTO.DTO.request;

public class VnPaymentRequest
{
    public int OrderId { get; set; }
    public long User_id { get; set; }
    public double Amount { get; set; }
    public DateTime CreatedDate { get; set; }
}
