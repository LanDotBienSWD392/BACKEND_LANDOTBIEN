using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using LanVar.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            return await _productRepository.SearchAsync(searchRequest);
        }
    }
}
