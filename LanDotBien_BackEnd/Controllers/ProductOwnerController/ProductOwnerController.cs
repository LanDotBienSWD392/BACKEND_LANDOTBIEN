using System.Net;
using AutoMapper;
using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
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
        private readonly IVnPayService _payService;
        private readonly IGenericRepository<Package> _genericPackageRepository;
        private readonly IPackageService _packageService;
        private readonly IGenericRepository<User_Package> _genericUserPackageRepository;
        private readonly IMapper _mapper;
        private readonly IUserPackageService _userPackageService;
        public ProductOwnerController(IProductService productService, IAccountService accountService,
        IVnPayService payService,IGenericRepository<Package> genericPackageRepository,IPackageService packageService,
        IGenericRepository<User_Package> genericUserPackageRepository, IMapper mapper, IUserPackageService userPackageService
        )
        {
            _productService = productService;
            _accountService = accountService;
            _payService = payService;
            _genericPackageRepository = genericPackageRepository;
            _packageService = packageService;
            _genericUserPackageRepository = genericUserPackageRepository;
            _mapper = mapper;
            _userPackageService = userPackageService;
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

        [HttpGet("GetProdcutByProductOwnerId")]
        public async Task<IActionResult> GetProdcutByProductOwnerId(long ownerId)
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
        [HttpPost("AddUserPackage"), Authorize]
        public async Task<IActionResult> UserPackageAdd(UserPackageDTORequest userPackageDtoRequest)
        {
            try
            {
                var packageAdd = await _userPackageService.AddUserPackage(userPackageDtoRequest);
                var response = new ApiResponse<User_Package>(packageAdd, HttpStatusCode.Accepted, "Package add success");
                return Ok(response); // Trả về kết quả thành công với dữ liệu UserPermission đã thêm
            }
            catch (CustomException.InvalidDataException ex)
            {
                var response = new ApiResponse<Package>(HttpStatusCode.Conflict, ex.Message);
                return BadRequest(response); // Trả về lỗi 400 Bad Request với thông báo lỗi
            }

        }
        


        [HttpPost("PurchasePackage"), Authorize]
        public async Task<string> CreatePayment(PaymentInformationModel billDtoRequest)
        {

            
            var paymentUrl = await _packageService.CreatePaymentUrl(billDtoRequest, HttpContext);
            var bill = await _genericPackageRepository.GetByIdAsync(long.Parse(billDtoRequest.OrderId));
            
            // Assuming PaymentResponseModel has a property to hold the payment URL
            return paymentUrl;
        
        }
        [HttpGet("Payment-CallBack")]
        public async Task<IActionResult> PaymentCallBack()
        {
            
            var response = _payService.PaymentExecute(Request.Query);
            if (response == null || response.VnPayResponseCode != "00")
            {
                throw new CustomException.InvalidDataException(HttpStatusCode.BadRequest.ToString(),"payment Fail");
            }

            User_Package bill = await _genericUserPackageRepository.GetByIdAsync(long.Parse(response.OrderId));
            bill.status = PackageStatus.Active;
         
            await _genericUserPackageRepository.Update(bill);
            
    
         
         


            return Ok("payment success");
        }
    }
}
