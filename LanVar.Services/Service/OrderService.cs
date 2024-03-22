using AutoMapper;
using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using LanVar.DTO.DTO.request;
using LanVar.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Tools.Tools;

namespace LanVar.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IGenericRepository<Order> _genericOrderRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IGenericRepository<Product> _genericProductRepository;
        private readonly IGenericRepository<OrderItem> _genericOrderItemRepository;
        private readonly IUserService _userService;
        
        private readonly IMapper _mapper;
        public OrderService(IOrderRepository orderRepository, 
            IMapper mapper,
            IGenericRepository<Order> genericOrderRepository,
            IOrderItemRepository orderItemRepository,
            IGenericRepository<Product> genericProductRepository,
            IGenericRepository<OrderItem> genericOrderItemRepository,
            IUserService userService
            )
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _genericProductRepository = genericProductRepository;
            _genericOrderRepository = genericOrderRepository;
            _orderItemRepository = orderItemRepository;
            _genericOrderItemRepository = genericOrderItemRepository;
            _userService = userService;

        }

        public async Task<Order> CreateOrder()
        {
            CreateOrderDTORequest createOrderDTORequest = new CreateOrderDTORequest();
            string userId = _userService.GetUserID();
            IEnumerable<OrderItem> orderItems = await _orderItemRepository.GetSelectedUserItem(long.Parse(userId));
            if (orderItems == null)
            {
                throw new CustomException.InvalidDataException(HttpStatusCode.BadRequest.ToString(),"Order Items invalid");
            }
    
            Order createdOrder = null; // Define the variable outside the loop to capture the last order created
            string code = await _orderRepository.GenerateNextOrderCodeAsync();
    
            foreach (var item in orderItems)
            {
                // Create a new Order object for each order item
                var order = _mapper.Map<Order>(createOrderDTORequest);
        
                var product = await _genericProductRepository.GetByIdAsync(item.product_id);
                // Ensure each order item is associated with the order
                order.orderItem_id = item.id;
                order.user_id = long.Parse(userId);
                order.total_Price = product.product_Price;
                order.date = DateTime.Now;
                order.status = OrderStatus.Waiting;
                order.orderCode = code;
                await _genericOrderRepository.Add(order);
                
        
                createdOrder = order; // Store the last created order
            }
    
            // Return the last created order
            return createdOrder;
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
