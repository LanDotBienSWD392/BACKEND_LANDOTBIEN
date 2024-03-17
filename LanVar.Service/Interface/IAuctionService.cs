using LanVar.Core.Entity;
using LanVar.DTO.DTO.request;
using LanVar.DTO.DTO.response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanVar.Service.Interface
{
    public interface IAuctionService
    {
        Task<AuctionDTOResponse> GetAuctionByIdAsync(long id);
        Task<IEnumerable<AuctionDTOResponse>> GetAllAuctionsAsync();
        Task<AuctionDTOResponse> CreateAuctionAsync(AuctionDTORequest auctionDTO);
        Task<AuctionDTOResponse> UpdateAuctionAsync(long id, AuctionDTORequest auctionDTO);
        Task<bool> DeleteAuctionAsync(long id);
    }
}
