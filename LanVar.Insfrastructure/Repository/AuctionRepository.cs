using System;
using AutoMapper;
using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LanVar.Insfrastructure.Repository
{
/*	public class AuctionRepository : GenericRepository<Auction>, IAuctionRepository
	{
        private readonly IMapper _mapper;
        public AuctionRepository(MyDbContext context) : base(context)
		{
            _mapper = _mapper;

        }

        public async Task<Auction> AddAsync(Auction auction)
        {
            await _context.Auctions.AddAsync(auction);
            return auction;
        }

        public async Task<IEnumerable<Auction>> GetAllAuctionsAsync()
        {
            return await _context.Auctions.ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }*/

    public class AuctionRepository : GenericRepository<Auction>, IAuctionRepository
    {
        
        private readonly IMapper _mapper;
        public AuctionRepository(MyDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }
        

        public async Task<Auction> GetByIdAsync(long id)
        {
            return await _context.Set<Auction>().FindAsync(id);
        }

        public async Task<IEnumerable<Auction>> GetAllAsync()
        {
            return await _context.Set<Auction>().ToListAsync();
        }

        public async Task<Auction> AddAsync(Auction entity)
        {
            _context.Set<Auction>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Auction> UpdateAsync(Auction entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null)
                return false;
            _context.Set<Auction>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
