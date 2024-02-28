using System;
using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace LanVar.Insfrastructure.Repository
{
	public class ProductRepository : GenericRepository<Product>, IProductRepository
	{
        
        public ProductRepository(MyDbContext context) : base(context)
        {
            
        }
	}
}

