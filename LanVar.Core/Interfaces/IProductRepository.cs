using System;
using LanVar.Core.Entity;

namespace LanVar.Core.Interfaces
{
    
    public interface IProductRepository : IGenericRepository<Product>
    {         
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<IEnumerable<Product>> GetByUserIdAsync(long ownerId);
        Task<IEnumerable<Product>> SearchProductsAsync(Product searchRequest);
    }
}

