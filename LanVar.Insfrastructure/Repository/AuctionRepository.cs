using System;
using AutoMapper;
using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LanVar.Insfrastructure.Repository
{
	public class AuctionRepository : GenericRepository<Auction>, IAuctionRepository
	{
        private readonly IMapper _mapper;
        public AuctionRepository(MyDbContext context) : base(context)
		{
            _mapper = _mapper;

        }

        public async Task<IEnumerable<Auction>> GetAllAuctionsAsync()
        {
            return await _context.Auctions.ToListAsync();
        }


    }
}

