using System;
using AutoMapper;
using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LanVar.Insfrastructure.Repository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly IMapper _mapper;

        public OrderRepository(MyDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<Order> AddAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            return order;
        }

        public async Task<IEnumerable<Order>> GetWaitingOrder(long id)
        {
            return _context.Orders.Where(x => x.status == OrderStatus.Waiting && x.user_id == id).ToList();
        }


        void IOrderRepository.Update(Order order)
        {
            _context.Orders.Update(order);
        }

        public async Task SaveChangesAsynce()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteOrder(long id)
        {
            var orderToDelete = await _context.Orders.FindAsync(id);
            if (orderToDelete == null)
            {
                return false;
            }

            _context.Orders.Remove(orderToDelete);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<string> GenerateNextOrderCodeAsync()
        {
            // Query the database to get the highest existing code
            string highestCode = await _context.Orders
                .Where(o => o.orderCode.StartsWith("SPX"))
                .Select(o => o.orderCode)
                .OrderByDescending(code => code)
                .FirstOrDefaultAsync();

            // Extract the numeric part and increment it
            int numericPart = 0;
            if (highestCode != null)
            {
                if (int.TryParse(highestCode.Substring(3), out numericPart))
                {
                    numericPart++;
                }
                else
                {
                    // Log or handle the case where the numeric part cannot be parsed
                }
            }

            // Format the numeric part as a 9-digit number with leading zeros
            string formattedNumericPart = numericPart.ToString("D9");

            // Concatenate "SPX" with the formatted numeric part
            string nextCode = "SPX" + formattedNumericPart;

            return nextCode;
        }

        public async Task<Order> GetByOrderCode(string orderCode)
        {
            return await _context.Orders.FirstOrDefaultAsync(x => x.orderCode.Equals(orderCode));
        }

        public async Task<double> Sum(string orderCode)
        {
            // Query the database to sum up the prices of orders with the specified order code
            double totalPrice = _context.Orders
                .Where(x => x.orderCode.Equals(orderCode))
                .Sum(o => o.total_Price);

            return totalPrice;
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

            // Remove the order from the context and save changes
            _context.Orders.Remove(orderToDelete);
            await _context.SaveChangesAsync();

            // Return true to indicate successful deletion
            return true;
        }

    }
}

