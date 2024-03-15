using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using LanVar.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;

namespace LanVar.Service.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _productRepository.GetAllProductsAsync();
        }

        public async Task<IEnumerable<Product>> SearchProductsAsync(SearchProductDTORequest searchRequest)
        {
            var search = _mapper.Map<Product>(searchRequest);
            return await _productRepository.SearchProductsAsync(search);
        }
    }
}
