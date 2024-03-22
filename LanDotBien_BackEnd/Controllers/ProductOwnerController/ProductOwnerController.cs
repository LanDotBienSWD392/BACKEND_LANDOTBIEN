using System.Net;
using LanVar.Core.Entity;
using LanVar.DTO.DTO.request;
using LanVar.DTO.DTO.response;

using LanVar.Service.Interface;

using LanVar.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tools.Tools;

namespace LanDotBien_BackEnd.Controllers.ProductOwnerController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductOwnerController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IUserService _userService;
        private readonly IAccountService _accountService;
        public ProductOwnerController(IProductService productService, IAccountService accountService)
        {
            _productService = productService;
            _accountService = accountService;
        }

        /*[HttpPost("CreateProduct"), Authorize]*/
        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductDTORequest createProductDtoRequest)
        {
            try
            {
                var productCreate = await _productService.CreateProduct(createProductDtoRequest);
                var response = new ApiResponse<ProductDTOResponse>(productCreate, HttpStatusCode.OK, "Product add success");
                return Ok(response); // Trả về kết quả thành công với dữ liệu UserPermission đã thêm
            }
            catch (CustomException.InvalidDataException ex)
            {
                var response = new ApiResponse<Package>(HttpStatusCode.Conflict, ex.Message);
                return BadRequest(response); // Trả về lỗi 400 Bad Request với thông báo lỗi
            }
        }

        [HttpGet("GetProductByProductOwnerId")]
        public async Task<IActionResult> GetProductByProductOwnerId(long ownerId)
        {
            try
            {
                // Gọi phương thức để lấy các sản phẩm của một chủ sở hữu sản phẩm cụ thể dựa trên ID
                IEnumerable<ProductDTOResponse> products = await _productService.GetProductsByOwnerId(ownerId);

                // Kiểm tra nếu không có sản phẩm được tìm thấy
                if (products == null || !products.Any())
                {
                    return NotFound(); // Trả về HTTP 404 Not Found
                }
                return Ok(products); // Trả về danh sách sản phẩm được tìm thấy
            }
            catch (CustomException.InvalidDataException ex)
            {
                return BadRequest(ex.Message); // Trả về HTTP 400 Bad Request với thông báo lỗi từ ngoại lệ
            }
        }


        [HttpPost("PurchasePackage")]
        public async Task<IActionResult> PurchasePackage(long userId)
        {
            
                var updatedUser = await _accountService.PurchasePackage(userId);
                return Ok(updatedUser);
        }
    }
}
