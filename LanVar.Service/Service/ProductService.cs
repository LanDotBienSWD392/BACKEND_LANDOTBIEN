using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using LanVar.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using LanVar.DTO.DTO.request;
using LanVar.DTO.DTO.response;
using Tools.Tools;

namespace LanVar.Service.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IGenericRepository<Product> _genericProductRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper,  IGenericRepository<Product> genericProductRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _genericProductRepository = genericProductRepository;
        }

        public async Task<IEnumerable<ProductDTOResponse>> GetAllProducts()
        {
            IEnumerable<Product> products = await _productRepository.GetAllProductsAsync();

            // Map each Product object to ProductDTOResponse
            IEnumerable<ProductDTOResponse> productResponses = _mapper.Map<IEnumerable<ProductDTOResponse>>(products);

            return productResponses;
        }

        public async Task<IEnumerable<Product>> SearchProductsAsync(SearchProductDTORequest searchRequest)
        {
            var search = _mapper.Map<Product>(searchRequest);
            return await _productRepository.SearchProductsAsync(search);
        }

        public async Task<ProductDTOResponse> CreateProduct(CreateProductDTORequest createProductDtoRequest)
        {
            string productName = createProductDtoRequest.Product_Name.ToString();
            if (string.IsNullOrEmpty(productName))
            {
                throw new CustomException.InvalidDataException(HttpStatusCode.BadRequest.ToString(),"Product name invalid");
            
            }
            var product = _mapper.Map<Product>(createProductDtoRequest);
            /*string userId = _userService.GetUserID();
            product.User_id = long.Parse(userId);*/
            product.status = true;
            Product addedProduct = await _genericProductRepository.Add(product);

            // Map the added product to ProductDTOResponse
            ProductDTOResponse productResponse = _mapper.Map<ProductDTOResponse>(addedProduct);

            return productResponse;
        }
        public async Task<IEnumerable<ProductDTOResponse>> GetProductsByOwnerId(long ownerId)
        {
            var products = await _productRepository.GetByUserIdAsync(ownerId);
            return _mapper.Map<IEnumerable<ProductDTOResponse>>(products);
        }

    }
}
