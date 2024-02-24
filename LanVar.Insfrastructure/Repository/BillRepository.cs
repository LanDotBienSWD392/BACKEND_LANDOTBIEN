using System;
using System.Security.Principal;
using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace LanVar.Insfrastructure.Repository
{
    public class BillRepository : GenericRepository<Bill>, IBillRepository
    {
        private readonly ILogger<BillRepository> _logger;
        public BillRepository(MyDbContext context, ILogger<BillRepository> logger) : base(context, logger)
        {
            _logger = logger;
        }
    }
}


