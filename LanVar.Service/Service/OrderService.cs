using AutoMapper;
using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using LanVar.DTO.DTO.request;
using LanVar.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanVar.Service.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        
        private readonly IMapper _mapper;
        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<Order> CreateOrder(CreateOrderDTORequest createOrderDTORequest)
        {
            var order = _mapper.Map<Order>(createOrderDTORequest);
            var addOrder = await _orderRepository.AddAsync(order);
            return addOrder;
        }
        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await _orderRepository.GetAllAsync();
        }

        public async Task<Order> GetOrderById(long id)
        {
            return await _orderRepository.GetByIdAsync(id);
        }
        public async Task<Order> UpdateOrder(long id, UpdateOrderDTORequest updateOrderDTORequest)
        {
            var orderToUpdate = await _orderRepository.GetByIdAsync(id);
            if (orderToUpdate != null) 
            {
                return null; // order not found
            }
            _mapper.Map(updateOrderDTORequest, orderToUpdate);

            _orderRepository.Update(orderToUpdate);
            await _orderRepository.GetAllAsync();
            return orderToUpdate;
        }
        public async Task<bool> DeleteOrder(long id)
        {
            var success = await _orderRepository.Delete(id);
            return success;
        }
    }
}
