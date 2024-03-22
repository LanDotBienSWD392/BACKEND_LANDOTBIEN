using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using LanVar.DTO.DTO.request;
using LanVar.Service.DTO.request;
using Microsoft.AspNetCore.SignalR;
using Tools.Tools;

namespace LanVar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BidController : ControllerBase
    {
        private readonly IBidService _bidService;
        private readonly IHubContext<BidHub> _hubContext;

        public BidController(IHubContext<BidHub> hubContext, IBidService bidService)
        {
            _hubContext = hubContext;
            _bidService = bidService;
        }

        [HttpPost("Bid")]
        public async Task<IActionResult> CreateBid([FromBody] BidDTORequest bidDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Tạo bid mới
                    await _bidService.CreateBid(bidDTO);

                    // Lấy thông tin highest bid sau khi bid mới đã được lưu vào cơ sở dữ liệu
                    var highestBid = await _bidService.GetHighestBid(bidDTO.auction_id);

                    // Gửi thông điệp bid mới tới tất cả các máy khách
                    await _hubContext.Clients.All.SendAsync("NewBid", highestBid);

                    return Ok("Bid created successfully.");
                }
                return BadRequest("Invalid bid data.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpGet("GetHighestBid/{id}")]
        public async Task<IActionResult> GetHighestBid(long id)
        {
            try
            {
                var highestBid = await _bidService.GetHighestBid(id);
                return Ok(highestBid);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /*[HttpPut("UpdateBid/{id}")]
        public async Task<IActionResult> UpdateBid(long id, [FromBody] BidDTORequest bidDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var existingBid = await _bidService.GetBidById(id);
                    if (existingBid == null)
                    {
                        return NotFound("Bid not found.");
                    }
                    bidDTO.id = id;
                    await _bidService.UpdateBid(bidDTO);
                    return Ok("Bid updated successfully.");
                }
                return BadRequest("Invalid bid data.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }*/

        [HttpDelete("DeleteBid/{id}")]
        public async Task<IActionResult> DeleteBid(long id)
        {
            try
            {
                var existingBid = await _bidService.GetBidById(id);
                if (existingBid == null)
                {
                    return NotFound("Bid not found.");
                }
                await _bidService.DeleteBid(id);
                return Ok("Bid deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
