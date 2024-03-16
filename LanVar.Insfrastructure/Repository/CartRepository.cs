using System;
using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace LanVar.Insfrastructure.Repository
{
	public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        
        public CartRepository(MyDbContext context) : base(context)
        {
           
        }
	}
}

