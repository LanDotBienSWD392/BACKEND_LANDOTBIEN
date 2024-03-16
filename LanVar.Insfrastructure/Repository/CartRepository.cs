using System;
using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LanVar.Insfrastructure.Repository
{
	public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        
        public CartRepository(MyDbContext context) : base(context)
        {
           
        }
        

        // public async Task<IEnumerable<Cart>> GetByUserIdAsync(long id)
        // {
	       //  return await _context.Carts.FirstOrDefaultAsync(u => u.User_id == id);
        // }
        public async Task<IEnumerable<Cart>> GetByUserIdAsync(long id)
        {
            var carts = await _context.Carts.Where(u => u.User_id == id).ToListAsync();
            return carts;
        }

    }
}

