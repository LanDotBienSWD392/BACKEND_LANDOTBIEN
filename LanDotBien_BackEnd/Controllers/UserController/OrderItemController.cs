using System.Net;
using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using LanVar.DTO.DTO.request;
using LanVar.DTO.DTO.response;
using LanVar.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tools.Tools;

namespace LanDotBien_BackEnd.Controllers.UserController
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;

        public OrderItemController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }
        [HttpPost("AddProductToOrderItem"), Authorize]
        public async Task<IActionResult> Post(OrderItemDTORequest orderItemDtoRequest)
        {
            try
            {
                var productCreate = await _orderItemService.AddItemToCart(orderItemDtoRequest);
                var response = new ApiResponse<OrderItemDTOResponse>(productCreate, HttpStatusCode.OK, "Product add success");
                return Ok(response); // Trả về kết quả thành công với dữ liệu UserPermission đã thêm
            }
            catch (CustomException.InvalidDataException ex)
            {
                var response = new ApiResponse<OrderItemDTOResponse>(HttpStatusCode.Conflict, ex.Message);
                return BadRequest(response); // Trả về lỗi 400 Bad Request với thông báo lỗi
            }

        }
        [HttpGet("GetAllUserItem"), Authorize]
        public async Task<IActionResult> GetAllRole()
        {
            var item = await _orderItemService.GetAllItemInCartByUserId();
            return Ok(item);
        }
        [HttpPut("SelectItem/{id}"), Authorize]
        public async Task<IActionResult> SelectItem(long id, SelectProductInCartDTORequest selectProductInCartDtoRequest)
        {
            try
            {
                var updatedRoles = await _orderItemService.SelectItem(id, selectProductInCartDtoRequest);
        
                // Assuming updatedRoles is a collection of OrderItemDTOResponse
                var response = new List<ApiResponse<OrderItemDTOResponse>>();
                foreach(var updatedRole in updatedRoles)
                {
                    response.Add(new ApiResponse<OrderItemDTOResponse>(updatedRole, HttpStatusCode.Accepted));
                }
                return Ok(response); // Return success result with the updated OrderItem data
            }
            catch (CustomException.InvalidDataException ex)
            {
                var response = new ApiResponse<OrderItemDTOResponse>(HttpStatusCode.Conflict, ex.Message);
                return BadRequest(response); // Return 400 Bad Request with the error message
            }
        }
        [HttpDelete("DeleteItemInOrderItem/{id}"), Authorize]
        public async Task<IActionResult> DeleteUserRole(long id)
        {
            try
            {
                var deleted = await _orderItemService.DeleteItemInCart(id);

                var response = new ApiResponse<string>("Item deleted successfully", HttpStatusCode.OK);
                return Ok(response);

            }
            catch (CustomException.InvalidDataException ex)
            {
                var response = new ApiResponse<string>(HttpStatusCode.NotFound, ex.Message);
                return NotFound(response);
            }
        }


    }
}
