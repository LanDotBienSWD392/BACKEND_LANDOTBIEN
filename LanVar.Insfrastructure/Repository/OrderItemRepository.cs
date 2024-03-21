using System;
using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LanVar.Insfrastructure.Repository
{
	public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
    {
        
        public OrderItemRepository(MyDbContext context, ILogger<OrderItemRepository> logger) : base(context)
        {
            
        }

        public async Task<IEnumerable<OrderItem>> GetAllByUserIdAsync(long id)
        {
            return _context.Items.Where(x => x.user_id == id).ToList();
        }

        public async Task<IEnumerable<OrderItem>> GetSelectedUserItem(long id)
        {
            return _context.Items.Where(x => x.user_id == id && x.isSelected == true && x.hidden == false).ToList();
        }
        public async Task<bool> DeleteOrderByOrderCode(string orderCode)
        {
            // Find the order with the given order code
            var orderToDelete = await _context.Orders.FirstOrDefaultAsync(x => x.orderCode.Equals(orderCode));

            if (orderToDelete == null)
            {
                // If the order with the given order code does not exist, return false
                return false;
            }

            // Find all order items associated with the order code
            var orderItemsToDelete = await _context.Items
                .Where(oi => oi.id == orderToDelete.orderItem_id)
                .ToListAsync();

            // Remove all order items from the context
            //_context.Items.RemoveRange(orderItemsToDelete);
            foreach (var orderItem in orderItemsToDelete)
            {
                orderItem.hidden = true;
            }


            // Remove the order itself from the context
            //_context.Items.Remove(orderToDelete);

            // Save the changes to the database
            await _context.SaveChangesAsync();

            // Return true to indicate successful deletion
            return true;
        }



    }
}

