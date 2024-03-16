using System;
using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace LanVar.Insfrastructure.Repository
{
	public class RoomRegistrationsRepository : GenericRepository<RoomRegistrations>, IRoomRegistrationsRepository
    {
        
        public RoomRegistrationsRepository(MyDbContext context) : base(context)
        {
            
        }
	}
}

