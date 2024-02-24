using System;
using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace LanVar.Insfrastructure.Repository
{
	public class BidRepository : GenericRepository<Bid>, IBidRepository
	{
        private readonly ILogger<BidRepository> _logger;
        public BidRepository(MyDbContext context, ILogger<BidRepository> logger) : base(context, logger)
        {
            _logger = logger;
        }
	}
}

