using System;
using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace LanVar.Insfrastructure.Repository
{
	public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
    {
        
        public OrderItemRepository(MyDbContext context, ILogger<OrderItemRepository> logger) : base(context)
        {
            
        }
	}
}

