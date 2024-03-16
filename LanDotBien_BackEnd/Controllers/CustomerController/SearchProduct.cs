using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using LanVar.Insfrastructure.Repository;
using LanVar.Service.Interface;
using LanVar.Service.Service;
using Microsoft.AspNetCore.Mvc;

namespace LanDotBien_BackEnd.Controllers.CustomerController
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchProduct : ControllerBase
    {
        private readonly IProductService _productService;

        public SearchProduct(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var products = await _productService.GetAllProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("SearchProducts")]
        public async Task<IActionResult> SearchProductsAsync(SearchProductDTORequest searchRequest)
        {
            try
            {
                var results = await _productService.SearchProductsAsync(searchRequest);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
