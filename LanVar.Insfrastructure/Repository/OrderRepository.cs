using System;
using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace LanVar.Insfrastructure.Repository
{
	public class OrderRepository : GenericRepository<Order>, IOrderRepository
	{
       
        public OrderRepository(MyDbContext context) : base(context)
        {
            
        }
	}
}

