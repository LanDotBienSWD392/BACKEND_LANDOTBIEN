/*using System;
using LanVar.Core.Entity;


namespace LanVar.Core.Interfaces
{
	*//*public interface IAuctionRepository : IGenericRepository<Auction>
	{
        Task<IEnumerable<Auction>> GetAllAuctionsAsync();
        Task<Auction> GetByIdAsync(long id);
        Task SaveChangesAsync();
        Task<Auction> AddAsync(Auction auction);
    }*//*

    public interface IAuctionRepository : IGenericRepository<Auction>
    {
        Task<Auction> GetByIdAsync(long id);
        Task<IEnumerable<Auction>> GetAllAsync();
        Task<Auction> AddAsync(Auction entity);
        Task<Auction> UpdateAsync(Auction entity);
        Task<bool> DeleteAsync(long id);
    }
}

*/
using LanVar.Core.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LanVar.Repository.IRepository
{
    public interface IAuctionRepository
    {
        Task<List<Auction>> GetAllAsync();
        Task<Auction> GetByIdAsync(long id);
        Task<Auction> CreateAsync(Auction auction);
        Task<Auction> UpdateAsync(Auction auction);
        Task<bool> DeleteAsync(long id);
        Task<Auction> GetByProductIdAsync(long productId);
        Task<Auction> GetByAuctionNameAsync(string auctionName);

    }
}

