using System;
using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace LanVar.Insfrastructure.Repository
{
	public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ILogger<UserRepository> _logger;
        public UserRepository(MyDbContext context, ILogger<UserRepository> logger) : base(context, logger)
        {
            _logger = logger;
        }
	}
}

