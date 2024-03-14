using System;
using LanVar.Core.Entity;

namespace LanVar.Core.Interfaces
{
    
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<IEnumerable<Product>> SearchProductsAsync(SearchProductDTORequest searchRequest);
    }
}

