using LanVar.Core.Entity;
using LanVar.DTO.DTO.request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanVar.Service.Interface
{
    public interface IOrderService
    {
        Task<Order> CreateOrder();
        Task<IEnumerable<Order>> GetAllOrders();
        Task<Order> GetOrderById(long id);
        Task<Order> UpdateOrder(long id, UpdateOrderDTORequest updateOrderDTORequest);
        Task<bool> DeleteOrder(long id);
    }
}
