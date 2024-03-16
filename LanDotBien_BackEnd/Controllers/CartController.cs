using System.Net;
using LanVar.Core.Entity;
using LanVar.DTO.DTO.request;
using LanVar.DTO.DTO.response;
using LanVar.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tools.Tools;

namespace LanDotBien_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }
        [HttpPost("AddItemToCart"), Authorize]
        public async Task<IActionResult> Post(CartDTORequest cartDtoRequest)
        {
            try
            {
                var cartAdd = await _cartService.AddItemToCart(cartDtoRequest);
                var response = new ApiResponse<CartDTOResponse>(cartAdd, HttpStatusCode.OK, "Product add success");
                return Ok(response); // Trả về kết quả thành công với dữ liệu UserPermission đã thêm
            }
            catch (CustomException.InvalidDataException ex)
            {
                var response = new ApiResponse<Package>(HttpStatusCode.Conflict, ex.Message);
                return BadRequest(response); // Trả về lỗi 400 Bad Request với thông báo lỗi
            }
           
        }
        [HttpGet("GetAllUserCartItem"), Authorize]
        public async Task<IActionResult> GetAllRole()
        {
            var cart = await _cartService.GetAllItemInCartByUserId();
            return Ok(cart);
        }

        [HttpPut("SelectProductInCart/{id}"), Authorize]
        public async Task<IActionResult> SelectProduct(long id, SelectProductInCartDTORequest selectProductInCart)
        {
            try
            {
                var updatedCart = await _cartService.UpdatedPackage(id, selectProductInCart);
                var cartShow = await _cartService.GetAllItemInCartByUserId();
                var response = new ApiResponse<CartDTOResponse>(updatedCart, HttpStatusCode.Accepted);
                return Ok(cartShow); // Return success result with the updated Cart data
            }
            catch (CustomException.InvalidDataException ex)
            {
                var response = new ApiResponse<Cart>(HttpStatusCode.Conflict, ex.Message);
                return BadRequest(response); // Return 400 Bad Request with the error message
            }
        }

        [HttpDelete("DeleteItemInCart/{id}"), Authorize]
        public async Task<IActionResult> DeleteItemInCart(long id)
        {
            try
            {
                var deletedItem = await _cartService.DeleteItemInCart(id);
                var response = new ApiResponse<string>("Item deleted successfully", HttpStatusCode.OK);
                return Ok(response);
                
            }
            catch (CustomException.InvalidDataException ex)
            {
                var response = new ApiResponse<Cart>(HttpStatusCode.Conflict, ex.Message);
                return BadRequest(response); // Return 400 Bad Request with the error message
            }
        }

    }
}
