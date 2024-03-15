using AutoMapper;
using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using LanVar.DTO.DTO.request;
using LanVar.DTO.DTO.response;
using LanVar.Service.Implementation;
using LanVar.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanVar.Service.Service
{
    public class AuctionService : IAuctionService
    {
        private readonly IGenericRepository<Auction> _auctionGenericRepository;
        private readonly IAuctionRepository _auctionRepository;
        private readonly IMapper _mapper;

        public AuctionService(
            IGenericRepository<Auction> auctionGenericRepository, IMapper mapper, IAuctionRepository auctionRepository
            )
        {
            _auctionRepository = auctionRepository;
            _auctionGenericRepository = auctionGenericRepository;
            _mapper = mapper;
        }

        public async Task<Auction> CreateAuction(AuctionDTORequest auctionDTORequest)
        {
            var auction = _mapper.Map<Auction>(auctionDTORequest);
            // Adding auction to repository
            return await _auctionGenericRepository.Add(auction);
        }

        public async Task<bool> DeleteAuction(long id)
        {
            return await _auctionGenericRepository.Delete(id);
        }

        public async Task<IEnumerable<AuctionDTOResponse>> GetAllAuctions()
        {
            IEnumerable<Auction> auctions = await _auctionRepository.GetAllAuctionsAsync();
            IEnumerable<AuctionDTOResponse> auctionDTOResponses = _mapper.Map<IEnumerable<AuctionDTOResponse>>(auctions);

            return auctionDTOResponses;
        }

        public async Task<Auction> GetAuctionById(long id)
        {
            return await _auctionRepository.GetByIdAsync(id);
        }

        public async Task<Auction> UpdateAuction(long id, AuctionDTORequest auctionDTORequest)
        {
            var existingAuction = await _auctionGenericRepository.GetByIdAsync(id);
            if (existingAuction == null)
                return null;

            // Map DTO to entity and update
            existingAuction = _mapper.Map(auctionDTORequest, existingAuction);

            // Update the auction
            await _auctionGenericRepository.Update(existingAuction);

            return existingAuction;
        }

        
    }
}
