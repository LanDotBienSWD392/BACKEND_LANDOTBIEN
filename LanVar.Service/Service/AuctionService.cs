using AutoMapper;
using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LanVar.Service.Implementation
{
    public class AuctionService : IAuctionRepository
    {
        private readonly IAuctionRepository _auctionRepository;

        private readonly IMapper _mapper;
        
        public AuctionService(IAuctionRepository auctionRepository, IMapper mapper)
        {
            _auctionRepository = auctionRepository;
            _mapper = mapper;

        }

        public async Task<Auction> Add(Auction entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Auction> entities)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Auction>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Auction>> GetByFilterAsync(Expression<Func<Auction, bool>> filterExpression)
        {
            throw new NotImplementedException();
        }

        public Task<Auction> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Auction> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Auction entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Auction> entities)
        {
            throw new NotImplementedException();
        }

        public Task<Auction> Update(Auction entity)
        {
            throw new NotImplementedException();
        }
    }
}
