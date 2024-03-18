using LanVar.Core.Entity;
using LanVar.DTO.DTO.request;
using LanVar.DTO.DTO.response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LanVar.Service.IService
{
    public interface IAuctionService
    {
        Task<List<AuctionDTOResponse>> GetAllAuctionsAsync();
        Task<AuctionDTOResponse> GetAuctionByIdAsync(long id);
        Task<AuctionDTOResponse> CreateAuctionAsync(AuctionDTORequest auctionDto);
        Task<AuctionDTOResponse> UpdateAuctionAsync(long id, AuctionDTORequest auctionDto);
        Task<bool> DeleteAuctionAsync(long id);
    }
}
