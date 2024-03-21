using LanVar.DTO.DTO.request;
using LanVar.DTO.DTO.response;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanVar.Service.Interface
{
    public interface IVnPayService
    {
        string CreatePaymentUrl(/*HttpContext context,*/ VnPaymentRequest model);
        VnPaymentResponse PaymentExecute(IQueryCollection collections);
    }
}
