using LanVar.DTO.DTO.request;
using LanVar.DTO.DTO.response;
using Microsoft.AspNetCore.Http;

namespace LanVar.Service.Interface;

public interface IVnPayService
{
    Task<string> CreatePaymentUrl(PaymentInformationModel model, HttpContext context);
    PaymentResponseModel PaymentExecute(IQueryCollection collections);
    Task<string> CreatePaymentDepositUrl(PaymentInformationModel model, HttpContext context);
}