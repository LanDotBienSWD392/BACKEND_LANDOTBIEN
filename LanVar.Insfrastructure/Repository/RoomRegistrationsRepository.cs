using System;
using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace LanVar.Insfrastructure.Repository
{
	public class RoomRegistrationsRepository : GenericRepository<RoomRegistrations>, IRoomRegistrationsRepository
    {
        private readonly ILogger<RoomRegistrations> _logger;
        public RoomRegistrationsRepository(MyDbContext context, ILogger<RoomRegistrations> logger) : base(context, logger)
        {
            _logger = logger;
        }
	}
}

