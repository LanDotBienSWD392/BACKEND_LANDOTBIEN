using System;
using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace LanVar.Insfrastructure.Repository
{
	public class AuctionRepository : GenericRepository<Auction>, IAuctionRepository
	{
       
        public AuctionRepository(MyDbContext context) : base(context)
		{
			
		}
	}
}

