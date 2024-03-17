using System;
using LanVar.Core.Entity;


namespace LanVar.Core.Interfaces
{
	/*public interface IAuctionRepository : IGenericRepository<Auction>
	{
        Task<IEnumerable<Auction>> GetAllAuctionsAsync();
        Task<Auction> GetByIdAsync(long id);
        Task SaveChangesAsync();
        Task<Auction> AddAsync(Auction auction);
    }*/

    public interface IAuctionRepository : IGenericRepository<Auction>
    {
        Task<Auction> GetByIdAsync(long id);
        Task<IEnumerable<Auction>> GetAllAsync();
        Task<Auction> AddAsync(Auction entity);
        Task<Auction> UpdateAsync(Auction entity);
        Task<bool> DeleteAsync(long id);
    }
}

