using System;
using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace LanVar.Insfrastructure.Repository
{
	public class PackageRepository : GenericRepository<Package>, IPackageRepository
	{
        private readonly ILogger<PackageRepository> _logger;
        public PackageRepository(MyDbContext context, ILogger<PackageRepository> logger) : base(context, logger)
        {
            _logger = logger;
        }
	}
}

