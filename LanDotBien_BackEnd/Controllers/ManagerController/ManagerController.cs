using LanVar.DTO.DTO.request;
using LanVar.Service.DTO.request;
using LanVar.Service.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LanDotBien_BackEnd.Controllers.ManagerController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public ManagerController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("GetAllStaff")]
        public async Task<IActionResult> GetAllStaff()
        {
            try
            {
                var users = await _accountService.GetAllUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetStaffById/{id}")]
        public async Task<IActionResult> GetStaffById(long id)
        {
            try
            {
                var user = await _accountService.GetUserById(id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("CreateStaff")]
        public async Task<IActionResult> CreateStaff([FromBody] UserRegisterRequest userRegisterRequest)
        {
            try
            {
                var createdUser = await _accountService.CreateUser(userRegisterRequest);
                return CreatedAtAction(nameof(GetStaffById), new { id = createdUser.id }, createdUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("UpdateStaff/{id}")]
        public async Task<IActionResult> UpdateStaff(long id, [FromBody] UpdateUserDTORequest updateUserDTORequest)
        {
            try
            {
                var updatedUser = await _accountService.UpdateUser(id, updateUserDTORequest);
                if (updatedUser == null)
                {
                    return NotFound();
                }
                return Ok(updatedUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("DeactivateStaff/{id}")]
        public async Task<IActionResult> DeactivateStaff(long id)
        {
            try
            {
                var result = await _accountService.DeactivateUser(id);
                if (!result)
                {
                    return NotFound();
                }
                return Ok(new { message = "User deactivated successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("ActivateStaff/{id}")]
        public async Task<IActionResult> ActivateStaff(long id)
        {
            try
            {
                var result = await _accountService.ActivateUser(id);
                if (!result)
                {
                    return NotFound();
                }
                return Ok(new { message = "User activated successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("DeleteStaff/{id}")]
        public async Task<IActionResult> DeleteStaff(long id)
        {
            try
            {
                var deletedUser = await _accountService.DeleteUser(id);
                if (deletedUser == null)
                {
                    return NotFound();
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
