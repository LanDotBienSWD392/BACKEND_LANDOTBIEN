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

namespace LanVar.Services.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IGenericRepository<Product> _genericProductRepository;
        private readonly IUserService _userService;
        private readonly IGenericRepository<User> _genericUserRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, 
            IMapper mapper,  
            IGenericRepository<Product> genericProductRepository, 
            IUserService userService,
            IGenericRepository<User> genericUserRepository
            )
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _genericProductRepository = genericProductRepository;
            _userService = userService;
            _genericUserRepository = genericUserRepository;
        }

        public async Task<IEnumerable<ProductDTOResponse>> GetAllProducts()
        {
            IEnumerable<Product> products = await _productRepository.GetAllProductsAsync();

            List<ProductDTOResponse> productResponses = new List<ProductDTOResponse>();

            // Map each Product object to ProductDTOResponse
            foreach (var product in products)
            {
                ProductDTOResponse productResponse = _mapper.Map<ProductDTOResponse>(product);
        
                // Fetch user ID and retrieve user details
                
                

                productResponses.Add(productResponse);
            }

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
            //string userId = _userService.GetUserID();
            //product.user_id = int.Parse(userId);
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
