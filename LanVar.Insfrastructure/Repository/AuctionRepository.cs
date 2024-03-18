/*using System;
using AutoMapper;
using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LanVar.Insfrastructure.Repository
{
*//*	public class AuctionRepository : GenericRepository<Auction>, IAuctionRepository
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
    }*//*

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
*/
using LanVar.Core.Entity;
using LanVar.Repository.IRepository;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LanVar.Repository.Repository
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly MyDbContext _context;

        public AuctionRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<Auction> CreateAsync(Auction auction)
        {
            _context.Auctions.Add(auction);
            await _context.SaveChangesAsync();
            return auction;
        }

        public async Task<Auction> GetByProductIdAsync(long productId)
        {
            return await _context.Auctions.FirstOrDefaultAsync(a => a.product_id == productId);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var auction = await _context.Auctions.FindAsync(id);
            if (auction == null)
                return false;

            // Chuyển trạng thái của đấu giá thành Inactive thay vì xóa nó
            auction.status = AuctionStatus.INACTIVE;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Auction> GetByAuctionNameAsync(string auctionName)
        {
            return await _context.Auctions.FirstOrDefaultAsync(a => a.auction_Name == auctionName);
        }
        public async Task<List<Auction>> GetAllAsync()
        {
            return await _context.Auctions
                .Include(auction => auction.product) // Liên kết với bảng Product
                .ToListAsync();
        }

        public async Task<Auction> GetByIdAsync(long id)
        {
            return await _context.Auctions
                .Include(auction => auction.product) // Liên kết với bảng Product
                .FirstOrDefaultAsync(auction => auction.product_id == id);
        }

        public async Task<Auction> UpdateAsync(Auction auction)
        {
            _context.Entry(auction).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return auction;
        }
    }
}

