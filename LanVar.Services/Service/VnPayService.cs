using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using LanVar.DTO.DTO.request;
using LanVar.DTO.DTO.response;
using LanVar.Service.Interface;
using LanVar.Service.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace LanVar.Service.Service;

public class VnPayService : IVnPayService
{
    private readonly IConfiguration _configuration;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IGenericRepository<Order> _genericOrderRepository;
    private readonly IGenericRepository<Bill> _genericBillRepository;
    private readonly IBillRepository _billRepository;

    public VnPayService(IConfiguration configuration, IHttpContextAccessor httpContextAccessor,
        IGenericRepository<Order> genericOrderRepository,
        IGenericRepository<Bill> genericBillRepository,
        IBillRepository billRepository
    )
    {
        _configuration = configuration;
        _httpContextAccessor = httpContextAccessor;
        _genericOrderRepository = genericOrderRepository;
        _genericBillRepository = genericBillRepository;
        _billRepository = billRepository;
    }

    public async Task<string> CreatePaymentUrl(PaymentInformationModel model, HttpContext context)
    {


        Bill bill = await _billRepository.GetByOrderCode(model.OrderId);
        var tick = DateTime.Now.Ticks.ToString();
        var vnpay = new VnPayLibrary();
        vnpay.AddRequestData("vnp_Version", _configuration["VnPay:Version"]);
        vnpay.AddRequestData("vnp_Command", _configuration["VnPay:Command"]);
        vnpay.AddRequestData("vnp_TmnCode", _configuration["VnPay:TmnCode"]);
        vnpay.AddRequestData("vnp_Amount", (bill.total_Price * 100).ToString()); //Số tiền thanh toán. Số tiền không mang các ký tự phân tách thập phân, phần nghìn, ký tự tiền tệ. Để gửi số tiền thanh toán là 100,000 VND (một trăm nghìn VNĐ) thì merchant cần nhân thêm 100 lần (khử phần thập phân), sau đó gửi sang VNPAY là: 10000000
        
        vnpay.AddRequestData("vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss"));
        vnpay.AddRequestData("vnp_CurrCode", _configuration["VnPay:CurrCode"]);
        vnpay.AddRequestData("vnp_IpAddr", Utils.GetIpAddress(context));
        vnpay.AddRequestData("vnp_Locale",_configuration["VnPay:Locale"]);
        vnpay.AddRequestData("vnp_OrderInfo", bill.orderCode);
        vnpay.AddRequestData("vnp_OrderType", "other"); //default value: other
        vnpay.AddRequestData("vnp_ReturnUrl", _configuration["VnPay:PaymentBackReturnUrl"]);
        vnpay.AddRequestData("vnp_TxnRef", tick);
        var paymentUrl = vnpay.CreateRequestUrl(_configuration["VnPay:BaseUrl"],
            _configuration["VnPay:HashSecret"]
        );
        
        return paymentUrl;
    }


    public PaymentResponseModel PaymentExecute(IQueryCollection collections)
    {
        var vnpay = new VnPayLibrary();
        foreach (var (key, value) in collections)
        {
            if (!string.IsNullOrEmpty(key) && key.StartsWith("vnp_"))
            {
                vnpay.AddResponseData(key, value.ToString());
            }
        }

        var vnp_orderId = vnpay.GetResponseData("vnp_OrderInfo");
        var vnp_TransactionId = Convert.ToInt64(vnpay.GetResponseData("vnp_TransactionNo"));
        var vnp_ResponseCode = vnpay.GetResponseData("vnp_ResponseCode");
        var vnp_SecureHash = collections.FirstOrDefault(p => p.Key == "vnp_SecureHash").Value;
        var vnp_OrderInfo = vnpay.GetResponseData("vnp_OrderInfo");
        bool checkSignature = vnpay.ValidateSignature(vnp_SecureHash, _configuration["VnPay:HashSecret"]);
        if (!checkSignature)
        {
            return new PaymentResponseModel
            {
                Success = false
            };
        }

        return new PaymentResponseModel
        {
            Success = true,
            PaymentMethod = "VnPay",
            OrderDescription = vnp_OrderInfo,
            OrderId = vnp_orderId,
            TransactionId = vnp_TransactionId.ToString(),
            Token = vnp_SecureHash,
            VnPayResponseCode = vnp_ResponseCode
        };


    }
}