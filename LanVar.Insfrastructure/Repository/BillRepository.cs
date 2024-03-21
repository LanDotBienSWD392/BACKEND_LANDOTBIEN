using System;
using System.Security.Principal;
using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LanVar.Insfrastructure.Repository
{
    public class BillRepository : GenericRepository<Bill>, IBillRepository
    {
        private readonly ILogger<BillRepository> _logger;
        public BillRepository(MyDbContext context) : base(context)
        {
            
        }

        public async Task<Bill> GetByOrderCode(string orderCode)
        {
            return await _context.Bills.FirstOrDefaultAsync(x => x.orderCode.Equals(orderCode));
        }
    }
}


