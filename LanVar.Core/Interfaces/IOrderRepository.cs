using System;
using LanVar.Core.Entity;

namespace LanVar.Core.Interfaces
{
	public interface IOrderRepository : IGenericRepository<Order>
	{
		Task<IEnumerable<Order>> GetAllAsync();
		Task<Order> GetByIdAsync(long id);
		void Update(Order order);
		Task SaveChangesAsynce();
		Task<bool> DeleteOrder(long id);
		Task<Order> AddAsync(Order order);
		Task<IEnumerable<Order>> GetWaitingOrder(long id);
		public Task<string> GenerateNextOrderCodeAsync();
		public Task<Order> GetByOrderCode(string orderCode);
		public Task<double> Sum(string orderCode);
		Task<bool> DeleteOrderByOrderCode(string id);
	}
}

