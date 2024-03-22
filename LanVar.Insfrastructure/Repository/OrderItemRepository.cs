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
            return _context.Items.Where(x => x.user_id == id && x.hidden == false).ToList();
        }

        public async Task<IEnumerable<OrderItem>> GetSelectedUserItem(long id)
        {
            return _context.Items.Where(x => x.user_id == id && x.isSelected == true && x.hidden == false).ToList();
        }
        public async Task<bool> DeleteOrderByOrderCode(string orderCode)
        {
            // Find all orders with the given order code
            var ordersToDelete = await _context.Orders.Where(x => x.orderCode.Equals(orderCode)).ToListAsync();

            if (ordersToDelete == null || ordersToDelete.Count == 0)
            {
                // If no orders with the given order code exist, return false
                return false;
            }

            foreach (var orderToDelete in ordersToDelete)
            {
                // Find all order items associated with the order code
                var orderItemsToDelete = await _context.Items
                    .Where(oi => oi.id == orderToDelete.orderItem_id) // Assuming orderId is used to link order items
                    .ToListAsync();

                // Update the Hidden property to true for each order item
                foreach (var orderItem in orderItemsToDelete)
                {
                    orderItem.hidden = true;
                }
            }

            // Save the changes to the database
            await _context.SaveChangesAsync();

            // Return true to indicate successful update
            return true;
        }




    }
}

