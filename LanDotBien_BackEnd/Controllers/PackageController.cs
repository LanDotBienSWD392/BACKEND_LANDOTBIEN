using System.Net;
using LanVar.Core.Entity;
using LanVar.Service.DTO.response;
using LanVar.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Tools.Tools;

namespace LanDotBien_BackEnd.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PackageController : ControllerBase
{
    private readonly IPackageService _packageService;

    public PackageController(IPackageService packageService)
    {
        _packageService = packageService;
    }
    [HttpPost("AddPackage")]
    public async Task<IActionResult> UserPermissionAdd(Package package)
    {
        try
        {
            var packageAdd = await _packageService.AddPackage(package);
            var response = new ApiResponse<Package>(packageAdd, HttpStatusCode.Accepted, "Package add success");
            return Ok(response); // Trả về kết quả thành công với dữ liệu UserPermission đã thêm
        }
        catch (CustomException.InvalidDataException ex)
        {
            var response = new ApiResponse<Package>(HttpStatusCode.Conflict, ex.Message);
            return BadRequest(response); // Trả về lỗi 400 Bad Request với thông báo lỗi
        }
        
    }
    [HttpGet("GetAllPackage")]
    public async Task<IActionResult> GetAllPackage()
    {
        var roles = await _packageService.GetAllRole();
        return Ok(roles);
    }
    [HttpPut("UpdatePackage/{id}")]
    public async Task<IActionResult> UpdateUserRole(long id, Package updatedPackage)
    {
        try
        {
            var updatePackage = await _packageService.UpdatedPackage(id, updatedPackage);
            var response = new ApiResponse<Package>(updatePackage, HttpStatusCode.Accepted);
            return Ok(response); // Return success result with the updated UserPermission data
        }
        
        catch (CustomException.InvalidDataException ex)
        {
            var response = new ApiResponse<Package>(HttpStatusCode.Conflict, ex.Message);
            return BadRequest(response); // Return 400 Bad Request with the error message
        }
    }
    [HttpDelete("DeleteUserRole/{id}")]
    public async Task<IActionResult> DeleteUserRole(long id)
    {
        try
        {
            var deleted = await _packageService.DeletePackage(id);
            
            var response = new ApiResponse<string>("Package deleted successfully", HttpStatusCode.OK);
            return Ok(response);
            
        }
        catch (CustomException.InvalidDataException ex)
        {
            var response = new ApiResponse<string>(HttpStatusCode.NotFound, ex.Message);
            return NotFound(response);
        }
    }
}