using System;
using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace LanVar.Insfrastructure.Repository
{
	public class UserPermissionRepository : GenericRepository<UserPermission>, IUserPermissionRepository
    {
        
        public UserPermissionRepository(MyDbContext context) : base(context)
        {
            
        }
	}
}

