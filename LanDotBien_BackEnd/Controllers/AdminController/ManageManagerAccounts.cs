using LanVar.Core.Entity;
using LanVar.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LanDotBien_BackEnd.Controllers.AdminController
{
    [Route("api/[controller]")]
    [ApiController]
    public class Manage_Manager_Accounts : ControllerBase
    {
        private readonly IAccountService _accountService;

        public Manage_Manager_Accounts(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("GetAllUser")]
        public async Task<IEnumerable<User>> GetAllUser()
        {
            return await _accountService.GetAllUsers();
        }

        [HttpGet("GetUserById/{id}")]
        public async Task<IActionResult> GetUserById(long id)
        {
            var user = await _accountService.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            var addedUser = await _accountService.AddUser(user);
            return CreatedAtAction(nameof(GetUserById), new { id = addedUser.id }, addedUser);
        }

        [HttpPut("UpdateUser/{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] User user)
        {
            var updatedUser = await _accountService.UpdateUser(id, user);

            if (updatedUser == null)
            {
                return NotFound();
            }

            return Ok(updatedUser);
        }

        [HttpPut("DeactivateUser/{id}")]
        public async Task<IActionResult> DeactivateUser(long id)
        {
            var result = await _accountService.DeactivateUser(id);

            if (result)
            {
                return Ok("Tài khoản đã bị khóa.");
            }
            else
            {
                return NotFound("Không tìm thấy tài khoản.");
            }
        }

        [HttpPut("ActivateUser/{id}")]
        public async Task<IActionResult> ActivateUser(long id)
        {
            var result = await _accountService.ActivateUser(id);

            if (result)
            {
                return Ok("Tài khoản đã được kích hoạt.");
            }
            else
            {
                return NotFound("Không tìm thấy tài khoản.");
            }
        }

        [HttpDelete("DeleteUser{id}")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            var result = await _accountService.DeactivateUser(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
