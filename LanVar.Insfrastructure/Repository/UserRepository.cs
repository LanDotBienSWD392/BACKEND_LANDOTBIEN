using System;
using System.Linq.Expressions;
using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LanVar.Insfrastructure.Repository
{
	public class UserRepository : GenericRepository<User>, IUserRepository
    {
        
        public UserRepository(MyDbContext context) : base(context)
        {
            
        }

        
	}
}

