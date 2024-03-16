using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanVar.Insfrastructure.Repository
{
    public class AuctionRepository : GenericRepository<Auction>, IAuctionRepository
    {
        public AuctionRepository(MyDbContext context) : base(context)
        {
        }
    }
}
