using AutoMapper;
using LanVar.Core.Entity;
using LanVar.DTO.DTO.request;
using LanVar.DTO.DTO.response;
using LanVar.Service.Interface;
using LanVar.Service.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Tools.Tools;

namespace LanDotBien_BackEnd.Controllers.UserController
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomRegistrationsController : ControllerBase
    {
        private readonly IVnPayService _vnPayService;
        private readonly IRoomRegistrationsService _roomRegistrationsService;
        private readonly IMapper _mapper;

        public RoomRegistrationsController(IVnPayService vnPayService, IRoomRegistrationsService roomRegistrationsService, IMapper mapper)
        {
            _vnPayService = vnPayService;
            _roomRegistrationsService = roomRegistrationsService;
            _mapper = mapper;
        }

        // Tạo đăng ký phòng
        [HttpPost("AddRoomRegistration")]
        public async Task<IActionResult> AddRoomRegistration(RoomRegistrationsDTORequest roomRegistrationsDTO)
        {
            try
            {
                var createdRoomRegistration = await _roomRegistrationsService.CreateAsync(roomRegistrationsDTO);
                var response = new ApiResponse<RoomRegistrationsDTOResponse>(createdRoomRegistration, HttpStatusCode.Accepted);
                return Ok(response);
            }
            catch (CustomException.InvalidDataException ex)
            {
                var response = new ApiResponse<RoomRegistrationsDTOResponse>(HttpStatusCode.Conflict, ex.Message);
                return BadRequest(response);
            }
        }



        // Thực hiện thanh toán đặt cọc
        [HttpPost("Deposit")]
        public async Task<IActionResult> Deposit(long roomRegistrationId)
        {
            try
            {
                var paymentModel = await _roomRegistrationsService.CreateDepositPayment(roomRegistrationId);
                // Gọi dịch vụ thanh toán của VnPay để lấy URL thanh toán

                var paymentUrl = await _vnPayService.CreatePaymentDepositUrl(paymentModel, HttpContext);

                // Cập nhật trạng thái đăng ký phòng từ "Deposit" thành "Waiting"
/*                    await _roomRegistrationsService.UpdateStatusToWaiting(roomRegistrationId);
*/
                // Trả về URL thanh toán cho người dùng
                return Ok(new { PaymentUrl = paymentUrl });
            }
            catch (CustomException.InvalidDataException ex)
            {
                var response = new ApiResponse<RoomRegistrationsDTOResponse>(HttpStatusCode.Conflict, ex.Message);
                return BadRequest(response);
            }
        }

        [HttpGet("Payment-CallBack")]
        public async Task<IActionResult> PaymentCallBack()
        {
            var response = _vnPayService.PaymentExecute(Request.Query);
            if (response == null || response.VnPayResponseCode != "00")
            {
                throw new CustomException.InvalidDataException(HttpStatusCode.BadRequest.ToString(), "payment Fail");
            }
            await _roomRegistrationsService.UpdateStatusToWaiting(long.Parse(response.OrderId));

            return Ok("payment success");
        }

        /*// Phương thức callback sau khi thanh toán
        [HttpGet("PaymentCallBack")]
        public async Task<IActionResult> PaymentCallBack(PaymentResponseModel paymentResponse)
        {
            try
            {

                if (paymentResponse.Success)
                {
                    // Xác minh tính hợp lệ của thanh toán
                    // Cập nhật trạng thái của đăng ký phòng từ "Waiting" thành trạng thái tương ứng
                    await _roomRegistrationsService.UpdateStatusAfterPayment(paymentResponse);
                    return Ok("Payment success");
                }
                else
                {
                    return BadRequest("Payment failed");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }*/


        [HttpGet("GetListUserInRoom/{id}")]
        public async Task<IActionResult> GetListUserInRoom(long id)
        {
            try
            {
                var roomRegistrations = await _roomRegistrationsService.GetByAuctionIdAsync(id);
                return Ok(roomRegistrations);
            }
            catch (CustomException.InvalidDataException ex)
            {
                var response = new ApiResponse<List<RoomRegistrationsDTOResponse>>(HttpStatusCode.NotFound, ex.Message);
                return NotFound(response);
            }
        }

        [HttpPut("AcceptUser/{id}")]
        public async Task<IActionResult> AcceptUser(long id)
        {
            try
            {
                var acceptedRoomRegistration = await _roomRegistrationsService.AcceptUser(id);
                var response = new ApiResponse<RoomRegistrationsDTOResponse>(acceptedRoomRegistration, HttpStatusCode.Accepted);
                return Ok(response);
            }
            catch (CustomException.InvalidDataException ex)
            {
                var response = new ApiResponse<RoomRegistrationsDTOResponse>(HttpStatusCode.NotFound, ex.Message);
                return NotFound(response);
            }
        }

        [HttpPut("UpdateRoomRegistration/{id}")]
        public async Task<IActionResult> UpdateRoomRegistration(long id, RoomRegistrationsDTORequest roomRegistrationsDTO)
        {
            try
            {
                var updatedRoomRegistration = await _roomRegistrationsService.UpdateAsync(id, roomRegistrationsDTO);
                var response = new ApiResponse<RoomRegistrationsDTOResponse>(updatedRoomRegistration, HttpStatusCode.Accepted);
                return Ok(response);
            }
            catch (CustomException.InvalidDataException ex)
            {
                var response = new ApiResponse<RoomRegistrationsDTOResponse>(HttpStatusCode.Conflict, ex.Message);
                return BadRequest(response);
            }
        }

        [HttpDelete("DeleteRoomRegistration/{id}")]
        public async Task<IActionResult> DeleteRoomRegistration(long id)
        {
            try
            {
                await _roomRegistrationsService.DeleteAsync(id);
                var response = new ApiResponse<string>("Room registration deleted successfully", HttpStatusCode.OK);
                return Ok(response);
            }
            catch (CustomException.InvalidDataException ex)
            {
                var response = new ApiResponse<string>(HttpStatusCode.NotFound, ex.Message);
                return NotFound(response);
            }
        }
    }
}
