﻿using System;
using AutoMapper;
using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
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
    }
}

