using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanVar.Insfrastructure.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(MyDbContext context) : base(context)
        {

        }
        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Set<Product>().ToList();
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Set<Product>().ToListAsync();
        }
    }
}
