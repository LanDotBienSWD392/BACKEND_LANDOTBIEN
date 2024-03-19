using LanVar.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanVar.DTO.DTO.request;
using LanVar.DTO.DTO.response;

namespace LanVar.Service.Interface
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTOResponse>> GetAllProducts();
        Task<IEnumerable<Product>> SearchProductsAsync(SearchProductDTORequest searchRequest);
        Task<ProductDTOResponse> CreateProduct(CreateProductDTORequest createProductDtoRequest);
    }

}
