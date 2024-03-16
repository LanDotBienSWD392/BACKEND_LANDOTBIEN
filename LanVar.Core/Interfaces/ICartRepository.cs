using System;
using LanVar.Core.Entity;

namespace LanVar.Core.Interfaces
{
	public interface ICartRepository : IGenericRepository<Cart>
	{
		Task<IEnumerable<Cart>> GetByUserIdAsync(long id);
	}
}

