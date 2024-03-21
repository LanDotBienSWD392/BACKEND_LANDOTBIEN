using System.Net;
using LanVar.Core.Entity;
using LanVar.DTO.DTO.response;
using LanVar.Service.Interface;

using Microsoft.AspNetCore.Mvc;
using Tools.Tools;

namespace LanDotBien_BackEnd.Controllers.UserController;
[Route("api/[controller]")]
[ApiController]
public class UserPermissionController : ControllerBase
{
    private readonly IUserPermissionService _userPermissionService;

    public UserPermissionController(IUserPermissionService userPermissionService)
    {
        _userPermissionService = userPermissionService;
    }

    [HttpPost("AddUserRole")]
    public async Task<IActionResult> UserPermissionAdd(UserPermission userPermission)
    {


        try
        {
            var role = await _userPermissionService.AddUserPermission(userPermission);
            var response = new ApiResponse<UserPermission>(role, HttpStatusCode.Accepted);
            return Ok(response); // Trả về kết quả thành công với dữ liệu UserPermission đã thêm
        }
        catch (CustomException.InvalidDataException ex)
        {
            var response = new ApiResponse<UserPermission>(HttpStatusCode.Conflict, ex.Message);
            return BadRequest(response); // Trả về lỗi 400 Bad Request với thông báo lỗi
        }



    }

    [HttpGet("GetAllUserRole")]
    public async Task<IActionResult> GetAllRole()
    {
        var roles = await _userPermissionService.GetAllRole();
        return Ok(roles);
    }
    [HttpPut("UpdateUserRole/{id}")]
    public async Task<IActionResult> UpdateUserRole(long id, UserPermission updatedUserPermission)
    {
        try
        {
            var updatedRole = await _userPermissionService.UpdateRole(id, updatedUserPermission);
            var response = new ApiResponse<UserPermission>(updatedRole, HttpStatusCode.Accepted);
            return Ok(response); // Return success result with the updated UserPermission data
        }

        catch (CustomException.InvalidDataException ex)
        {
            var response = new ApiResponse<UserPermission>(HttpStatusCode.Conflict, ex.Message);
            return BadRequest(response); // Return 400 Bad Request with the error message
        }
    }

    [HttpDelete("DeleteUserRole/{id}")]
    public async Task<IActionResult> DeleteUserRole(long id)
    {
        try
        {
            var deleted = await _userPermissionService.DeleteRole(id);

            var response = new ApiResponse<string>("Role deleted successfully", HttpStatusCode.OK);
            return Ok(response);

        }
        catch (CustomException.InvalidDataException ex)
        {
            var response = new ApiResponse<string>(HttpStatusCode.NotFound, ex.Message);
            return NotFound(response);
        }
    }
}