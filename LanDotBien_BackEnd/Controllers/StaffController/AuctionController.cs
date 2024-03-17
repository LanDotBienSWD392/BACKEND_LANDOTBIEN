using LanVar.Core.Entity;
using LanVar.DTO.DTO.request;
using LanVar.DTO.DTO.response;
using LanVar.Service.DTO.request;
using LanVar.Service.Implementation;
using LanVar.Service.Interface;
using LanVar.Service.Service;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Tools.Tools;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LanDotBien_BackEnd.Controllers.StaffController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionController : ControllerBase
    {
        private readonly IAuctionService _auctionService;

        public AuctionController(IAuctionService auctionService)
        {
            _auctionService = auctionService;
        }

        // GET: api/<AuctionController>
        [HttpGet("GetAllAuction")]
        public async Task<IActionResult> GetAllAuction()
        {
            try
            {
                var auction = await _auctionService.GetAllAuctionsAsync();
                return Ok(auction);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetAuctionById/{id}")]
        public async Task<IActionResult> GetAuctionById(long id)
        {
            try
            {
                var auction = await _auctionService.GetAuctionByIdAsync(id);
                if (auction == null)
                {
                    return NotFound();
                }
                return Ok(auction);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST api/<AuctionController>
        [HttpPost("CreateAuction")]
        public async Task<IActionResult> CreateAuctions(AuctionDTORequest auctionDTORequest)
        {
            try
            {
                var auctionCreate = await _auctionService.CreateAuctionAsync(auctionDTORequest);
/*                var response = new ApiResponse<Auction>(auctionCreate, HttpStatusCode.OK, "Auction add success");
*/                return Ok(auctionCreate); // Trả về kết quả thành công với dữ liệu UserPermission đã thêm
            }
            catch (CustomException.InvalidDataException ex)
            {
                var response = new ApiResponse<Auction>(HttpStatusCode.Conflict, ex.Message);
                return BadRequest(response); // Trả về lỗi 400 Bad Request với thông báo lỗi
            }
        }

        // PUT api/<AuctionController>/5
        [HttpPut("UpdateAuction/{id}")]
        public async Task<IActionResult> UpdateAuction(long id, [FromBody] AuctionDTORequest auctionDTORequest)
        {
            try
            {
                var updatedAuction = await _auctionService.UpdateAuctionAsync(id, auctionDTORequest);
                if (updatedAuction == null)
                {
                    return NotFound();
                }
                return Ok(updatedAuction);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE api/<AuctionController>/5
        [HttpDelete("DeleteAuction/{id}")]
        public async Task<IActionResult> DeleteAuction(long id)
        {
            try
            {
                var existingAuction = await _auctionService.DeleteAuctionAsync(id);
                if (existingAuction == null)
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
