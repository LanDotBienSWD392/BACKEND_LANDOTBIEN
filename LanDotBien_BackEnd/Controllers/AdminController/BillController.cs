using System.Net;
using LanVar.DTO.DTO.request;
using LanVar.DTO.DTO.response;
using LanVar.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tools.Tools;

[Route("api/[controller]")]
[ApiController]
public class BillController : ControllerBase
{
    private readonly IBillService _billService;

    public BillController(IBillService billService)
    {
        _billService = billService;
    }

    [HttpPost("CreateBill"), Authorize] // Explicitly specify the HTTP method
    public async Task<IActionResult> UserPermissionAdd(BillDTORequest billDtoRequest)
    {
        try
        {
            var packageAdd = await _billService.CreateBill(billDtoRequest);
            var response = new ApiResponse<BillDTOResponse>(packageAdd, HttpStatusCode.Accepted, "Package add success");
            return Ok(response); // Trả về kết quả thành công với dữ liệu UserPermission đã thêm
        }
        catch (CustomException.InvalidDataException ex)
        {
            var response = new ApiResponse<BillDTOResponse>(HttpStatusCode.Conflict, ex.Message);
            return BadRequest(response); // Trả về lỗi 400 Bad Request với thông báo lỗi
        }
    }
}