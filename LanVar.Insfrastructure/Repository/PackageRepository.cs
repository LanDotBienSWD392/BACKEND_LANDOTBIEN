using System;
using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace LanVar.Insfrastructure.Repository
{
	public class PackageRepository : GenericRepository<Package>, IPackageRepository
	{
       
        public PackageRepository(MyDbContext context) : base(context)
        {
            
        }
	}
}

