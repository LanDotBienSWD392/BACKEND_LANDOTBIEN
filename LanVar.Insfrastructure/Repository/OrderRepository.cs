using System;
using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace LanVar.Insfrastructure.Repository
{
	public class OrderRepository : GenericRepository<Order>, IOrderRepository
	{
        private readonly ILogger<OrderRepository> _logger; 
        public OrderRepository(MyDbContext context, ILogger<OrderRepository> logger) : base(context, logger)
        {
            _logger = logger;
        }
	}
}

