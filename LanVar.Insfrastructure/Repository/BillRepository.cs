using System;
using System.Security.Principal;
using AutoMapper;
using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LanVar.Insfrastructure.Repository
{
    public class BillRepository : GenericRepository<Bill>, IBillRepository
    {
        private readonly ILogger<BillRepository> _logger;
        private readonly IMapper _mapper;
        public BillRepository(MyDbContext context) : base(context)
        {
            _mapper = _mapper;
        }

        public async Task<IEnumerable<Bill>> GetAllBillsAsync()
        {
            return await _context.Bills.ToListAsync();
        }

        public async Task<Bill> GetByOrderCode(string orderCode)
        {
            return await _context.Bills.FirstOrDefaultAsync(x => x.orderCode.Equals(orderCode));
        }
    }
}


