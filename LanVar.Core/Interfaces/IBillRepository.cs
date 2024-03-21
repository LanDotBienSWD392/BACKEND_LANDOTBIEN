using System;
using LanVar.Core.Entity;

namespace LanVar.Core.Interfaces
{
	public interface IBillRepository: IGenericRepository<Bill>
	{
		public Task<Bill> GetByOrderCode(string orderCode);
	}
}

