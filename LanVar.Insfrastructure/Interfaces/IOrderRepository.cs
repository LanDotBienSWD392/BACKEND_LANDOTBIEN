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
	}
}

