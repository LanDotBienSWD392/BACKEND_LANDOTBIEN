using System;
using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace LanVar.Insfrastructure.Repository
{
	public class ProductRepository : GenericRepository<Product>, IProductRepository
	{
        private readonly ILogger<ProductRepository> _logger;
        public ProductRepository(MyDbContext context, ILogger<ProductRepository> logger) : base(context, logger)
        {
            _logger = logger;
        }
	}
}

