using System;
using LanVar.Core.Entity;

namespace LanVar.Core.Interfaces
{
	public interface IOrderItemRepository : IGenericRepository<OrderItem>
	{
		Task<IEnumerable<OrderItem>> GetAllByUserIdAsync(long id);
		Task<IEnumerable<OrderItem>> GetSelectedUserItem(long id);
		Task<bool> DeleteOrderByOrderCode(string id);
	}
}

