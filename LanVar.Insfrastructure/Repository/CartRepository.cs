using System;
using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace LanVar.Insfrastructure.Repository
{
	public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        private readonly ILogger<CartRepository> _logger;
        public CartRepository(MyDbContext context, ILogger<CartRepository> logger) : base(context, logger)
        {
            _logger = logger;
        }
	}
}

