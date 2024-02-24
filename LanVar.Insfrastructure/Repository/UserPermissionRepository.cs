using System;
using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace LanVar.Insfrastructure.Repository
{
	public class UserPermissionRepository : GenericRepository<UserPermission>, IUserPermissionRepository
    {
        private readonly ILogger<UserPermissionRepository> _logger;
        public UserPermissionRepository(MyDbContext context, ILogger<UserPermissionRepository> logger) : base(context, logger)
        {
            _logger = logger;
        }
	}
}

