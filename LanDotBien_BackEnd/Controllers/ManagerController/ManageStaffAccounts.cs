using LanVar.DTO.DTO.request;
using LanVar.Service.DTO.request;
using LanVar.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Tools.Tools;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LanDotBien_BackEnd.Controllers.ManagerController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageStaffAccounts : ControllerBase
    {
        private readonly IAccountService _accountService;
        // GET: api/<ManageStaffAccounts>
        [HttpGet("GetAllStaff")]
        public async Task<IActionResult> GetAllUser()
        {
            try
            {
                var users = await _accountService.GetAllUsers();
                return Ok(users);
            }
            catch (CustomException.InvalidDataException ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET api/<ManageStaffAccounts>/5
        [HttpGet("GetStaffById{id}")]
        public async Task<IActionResult> GetUserById(long id)
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
            catch (CustomException.InvalidDataException ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST api/<ManageStaffAccounts>
        [HttpPost("CreateStaff")]
        public async Task<IActionResult> CreateUser([FromBody] CreateAccountDTORequest createAccountRequest)
        {
            try
            {
                var createdUser = await _accountService.CreateUser(createAccountRequest);
                return CreatedAtAction(nameof(GetUserById), new { id = createdUser.id }, createdUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT api/<ManageStaffAccounts>/5
        [HttpPut("UpdateStaff{id}")]
        public async Task<IActionResult> UpdateUser(long id, [FromBody] UpdateUserDTORequest updateUserDTORequest)
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
        public async Task<IActionResult> DeactivateUser(long id)
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
        public async Task<IActionResult> ActivateUser(long id)
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
        public async Task<IActionResult> DeleteUser(long id)
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
