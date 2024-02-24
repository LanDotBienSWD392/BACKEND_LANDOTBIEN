using System;
using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace LanVar.Insfrastructure.Repository
{
	public class AuctionRepository : GenericRepository<Auction>, IAuctionRepository
	{
        private readonly ILogger<AuctionRepository> _logger;
        public AuctionRepository(MyDbContext context, ILogger<AuctionRepository> logger) : base(context, logger)
		{
			_logger = logger;
		}
	}
}

