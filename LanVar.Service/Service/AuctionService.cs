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
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Tools.Tools;

namespace LanVar.Service.Service
{
    public class AuctionService : IAuctionService
    {
        private readonly IAuctionRepository _auctionRepository;
        private readonly IMapper _mapper;

        public AuctionService(IAuctionRepository auctionRepository, IMapper mapper)
        {
            _auctionRepository = auctionRepository;
            _mapper = mapper;
        }

        public async Task<AuctionDTOResponse> GetAuctionByIdAsync(long id)
        {
            var auction = await _auctionRepository.GetByIdAsync(id);
            return _mapper.Map<AuctionDTOResponse>(auction);
        }

        public async Task<IEnumerable<AuctionDTOResponse>> GetAllAuctionsAsync()
        {
            var auctions = await _auctionRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<AuctionDTOResponse>>(auctions);
        }

        public async Task<AuctionDTOResponse> CreateAuctionAsync(AuctionDTORequest auctionDTO)
        {
            var auctionEntity = _mapper.Map<Auction>(auctionDTO);
            var addedAuction = await _auctionRepository.AddAsync(auctionEntity);
            return _mapper.Map<AuctionDTOResponse>(addedAuction);
        }

        public async Task<AuctionDTOResponse> UpdateAuctionAsync(long id, AuctionDTORequest auctionDTO)
        {
            var existingAuction = await _auctionRepository.GetByIdAsync(id);
            if (existingAuction == null)
                return null;

            _mapper.Map(auctionDTO, existingAuction);
            var updatedAuction = await _auctionRepository.UpdateAsync(existingAuction);
            return _mapper.Map<AuctionDTOResponse>(updatedAuction);
        }

        public async Task<bool> DeleteAuctionAsync(long id)
        {
            return await _auctionRepository.DeleteAsync(id);
        }

    }
}
