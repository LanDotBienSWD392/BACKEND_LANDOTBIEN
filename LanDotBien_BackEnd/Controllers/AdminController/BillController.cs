using System.Net;
using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using LanVar.DTO.DTO.request;
using LanVar.DTO.DTO.response;
using LanVar.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Tools.Tools;

[Route("api/[controller]")]
[ApiController]
public class BillController : ControllerBase
{
    private readonly IBillService _billService;
    private readonly IVnPayService _payService;
    private readonly IBillRepository _billRepository;
    private readonly IGenericRepository<Bill> _genericRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IGenericRepository<Order> _genericOrderRepository;
    

    public BillController(IBillService billService, IVnPayService payService, IBillRepository billRepository, IGenericRepository<Bill> genericRepository,
        IOrderRepository orderRepository, IGenericRepository<Order> genericOrderRepository)
    {
        _billService = billService;
        _payService = payService;
        _billRepository = billRepository;
        _genericRepository = genericRepository;
        _orderRepository = orderRepository;
        _genericOrderRepository = genericOrderRepository;
    }

    [HttpPost("CreateBill"), Authorize] // Explicitly specify the HTTP method
    public async Task<IActionResult> CreateBill(BillDTORequest billDtoRequest)
    {
        try
        {
            var bill = await _billService.CreateBill(billDtoRequest);
            var response = new ApiResponse<BillDTOResponse>(bill, HttpStatusCode.Accepted, "Package add success");
            return Ok(response); // Trả về kết quả thành công với dữ liệu UserPermission đã thêm
        }
        catch (CustomException.InvalidDataException ex)
        {
            var response = new ApiResponse<BillDTOResponse>(HttpStatusCode.Conflict, ex.Message);
            return BadRequest(response); // Trả về lỗi 400 Bad Request với thông báo lỗi
        }
    }
    [HttpPost("PaymentCallBack"), Authorize] // Explicitly specify the HTTP method
    public async Task<string> CreatePayment(PaymentInformationModel billDtoRequest)
    {
       
        var paymentUrl = await _payService.CreatePaymentUrl(billDtoRequest, HttpContext);
        Bill bill = await _billRepository.GetByOrderCode(billDtoRequest.OrderId);
        bill.paymentUrl = paymentUrl;
        await _genericRepository.Update(bill);
            // Assuming PaymentResponseModel has a property to hold the payment URL
        return paymentUrl;
        
    }

    [HttpGet("Payment-CallBack")]
    public async Task<IActionResult> PaymentCallBack()
    {
        var response = _payService.PaymentExecute(Request.Query);
        if (response == null || response.VnPayResponseCode != "00")
        {
            throw new CustomException.InvalidDataException(HttpStatusCode.BadRequest.ToString(),"payment Fail");
        }

        Bill bill = await _billRepository.GetByOrderCode(response.OrderId);
        bill.status = true;
         
        await _genericRepository.Update(bill);
        IEnumerable<Order> order = await _orderRepository.GetByOrderCode(response.OrderId);
        foreach (var hidden in order)
        {
            hidden.status = OrderStatus.Confirmed;
            await _genericOrderRepository.Update(hidden);
        }
        return Ok("payment success");
    }
    


    
}