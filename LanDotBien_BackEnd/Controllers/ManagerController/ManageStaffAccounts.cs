using LanVar.Core.Entity;
using LanVar.DTO.DTO.request;
using LanVar.Service.DTO.request;
using LanVar.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;
using LanVar.Services.Interface;
using Tools.Tools;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LanDotBien_BackEnd.Controllers.ManagerController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageStaffAccounts : ControllerBase
    {
        private readonly IAccountService _accountService;

        public ManageStaffAccounts(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("GetAllStaff")]
        public async Task<IActionResult> GetAllStaffUsers()
        {
            try
            {
                var users = await _accountService.GetAllStaffUsers();
                if (users == null || !users.Any()) // Kiểm tra nếu không có người dùng nào được trả về
                {
                    return NotFound("Đéo Có User Nào Hết"); // Báo trạng thái "Not Found" (404)
                }
                return Ok(users);
            }
            catch (CustomException.InvalidDataException ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("CreateStaff")]
        public async Task<IActionResult> CreateStaffUser([FromBody] CreateAccountDTORequest createAccountDTORequest)
        {
            try
            {
                User user = await _accountService.CreateStaffUser(createAccountDTORequest);
                return Ok(createAccountDTORequest);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT api/<ManageStaffAccounts>/5
        [HttpPut("UpdateStaff/{id}")]
        public async Task<IActionResult> UpdateStaffUser(long id, [FromBody] UpdateUserDTORequest updateUserDTORequest)
        {
            try
            {
                var updatedUser = await _accountService.UpdateStaffUser(id, updateUserDTORequest);
                if (updatedUser == null)
                {
                    return NotFound("Không Tìm Thấy Account");
                }
                return Ok(updatedUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpDelete("DeleteStaff/{id}")]
        public async Task<IActionResult> DeleteStaffUser(long id)
        {
            try
            {
                var deletedUser = await _accountService.DeleteStaffUser(id);
                if (deletedUser == null)
                {
                    return NotFound("Không Tìm Thấy Account");
                }
                return Ok(new { message = "User deleted successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
