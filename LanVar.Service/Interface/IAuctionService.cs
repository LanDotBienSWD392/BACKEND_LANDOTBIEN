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
        Task<Auction> CreateAuction(AuctionDTORequest auctionDTORequest);
        Task<IEnumerable<AuctionDTOResponse>> GetAllAuctions();
        Task<Auction> UpdateAuction(long id, AuctionDTORequest auctionDTORequest);
        Task<bool> DeleteAuction(long id);
        Task<Auction> GetAuctionById(long id);
    }
}
