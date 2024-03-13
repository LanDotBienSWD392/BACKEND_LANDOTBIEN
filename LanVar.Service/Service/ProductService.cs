using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using LanVar.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanVar.Service.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _productRepository.GetAllProductsAsync();
        }

        public async Task<IEnumerable<Product>> SearchProductsAsync(SearchProductDTORequest searchRequest)
        {
            var query = _productRepository.GetAllProducts().AsQueryable();

            if (!string.IsNullOrEmpty(searchRequest.Product_Name))
            {
                query = query.Where(p => p.Product_Name.Contains(searchRequest.Product_Name));
            }

            // Thêm các điều kiện tìm kiếm khác nếu cần thiết

            return await query.ToListAsync();
        }

        public async Task<bool> BuyProductAsync(int productId)
        {
            var product = await _productRepository.GetProductByIdAsync(productId);

            if (product != null)
            {
                // Triển khai logic mua sản phẩm ở đây
                // Ví dụ: Cập nhật trạng thái sản phẩm, thêm vào giỏ hàng, xử lý thanh toán, v.v.

                // Sau khi mua thành công, cập nhật trạng thái sản phẩm
                product.Status = false;
                await _productRepository.UpdateProductAsync(product);

                return true; // Mua sản phẩm thành công
            }

            return false; // Sản phẩm không tồn tại hoặc có lỗi trong quá trình mua
        }
    }
}
