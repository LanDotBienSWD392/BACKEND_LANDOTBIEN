using AutoMapper;
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
        private readonly IMapper _mapper;
        public ProductRepository(MyDbContext context) : base(context)
        {
            _mapper = _mapper;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<IEnumerable<Product>> SearchProductsAsync(Product searchRequest)
        {
            return await _context.Products
                .Where(p => p.ISBN == searchRequest.ISBN && p.Product_Name == searchRequest.Product_Name && p.Product_Price == searchRequest.Product_Price)
                .ToListAsync();
        }
    }
}
