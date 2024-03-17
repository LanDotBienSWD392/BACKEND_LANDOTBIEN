using LanVar.DTO.DTO.request;
using LanVar.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Tools.Tools;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LanDotBien_BackEnd.Controllers.StaffController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageOrder : ControllerBase
    {
        private readonly IOrderService _ordererService;

        public ManageOrder (IOrderService orderService)
        {
            _ordererService = orderService;
        }
        // GET: api/<ManageOrder>
        [HttpGet("GetAllOrder")]
        public async Task<IActionResult> GetAllOrders()
        {
            try
            {
                var orders = await _ordererService.GetAllOrders();
                return Ok(orders);
            }
            catch (CustomException.InvalidDataException ex)
            {
                return StatusCode(500, $"Interal server error: {ex.Message}");
            }
        }

        // GET api/<ManageOrder>/5
        [HttpGet("GetOrderById/{id}")]
        public async Task<IActionResult> GetOrderById(long id)
        {
            try
            {
                var orders = await _ordererService.GetOrderById(id);
                if (orders == null)
                {
                    return NotFound();
                }
                return Ok(orders);
            }
            catch (CustomException.InvalidDataException ex)
            {
                return StatusCode(500, $"Interal server error: {ex.Message}");
            }
        }

        // POST api/<ManageOrder>
        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDTORequest createOrderDTORequest)
        {
            try
            {
                var createOrder = await _ordererService.CreateOrder(createOrderDTORequest);
                return CreatedAtAction(nameof(GetOrderById), new { id = createOrder.id }, createOrder);
            }
            catch (CustomException.InvalidDataException ex)
            {
                return StatusCode(500, $"Interal server error: {ex.Message}");
            }
        }


        // PUT api/<ManageOrder>/5
        [HttpPut("UpdateOrder/{id}")]
        public async Task<IActionResult> UpdateOrder(long id, [FromBody] UpdateOrderDTORequest updateOrderDTORequest)
        {
            try
            {
                var updateOrder = await _ordererService.UpdateOrder(id, updateOrderDTORequest);
                if (updateOrder == null)
                {
                    return NotFound();
                }
                return Ok(updateOrder);
            }
            catch (CustomException.InvalidDataException ex)
            {
                return StatusCode(500, $"Interal server error: {ex.Message}");
            }
        }

        // DELETE api/<ManageOrder>/5
        [HttpDelete("DeleteOrder/{id}")]
        public async Task<IActionResult> DeleteOrder (long id)
        {
            try
            {
                var deleteOrder = await _ordererService.DeleteOrder(id);
                if (deleteOrder == null)
                {
                    return NotFound();
                }
                return Ok(deleteOrder);
            }
            catch (CustomException.InvalidDataException ex)
            {
                return StatusCode(500, $"Interal server error: {ex.Message}");
            }
        }
    }
}
