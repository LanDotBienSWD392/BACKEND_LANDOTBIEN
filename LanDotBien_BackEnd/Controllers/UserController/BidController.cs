using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using LanVar.DTO.DTO.request;
using LanVar.Service.DTO.request;

namespace LanVar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BidController : ControllerBase
    {
        private readonly IBidService _bidService;

        public BidController(IBidService bidService)
        {
            _bidService = bidService;
        }

        [HttpPost("Bid")]
        public async Task<IActionResult> CreateBid([FromBody] BidDTORequest bidDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _bidService.CreateBid(bidDTO);
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
