using System;
using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace LanVar.Insfrastructure.Repository
{
	public class BidRepository : GenericRepository<Bid>, IBidRepository
	{
        
        public BidRepository(MyDbContext context) : base(context)
        {
            
        }
	}
}

