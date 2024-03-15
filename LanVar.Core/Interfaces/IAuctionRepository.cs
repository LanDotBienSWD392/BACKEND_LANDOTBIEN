using System;
using LanVar.Core.Entity;

namespace LanVar.Core.Interfaces
{
	public interface IAuctionRepository : IGenericRepository<Auction>
	{
        Task<IEnumerable<Auction>> GetAllAuctionsAsync();
        Task<Auction> GetByIdAsync(long id);
    }
}

