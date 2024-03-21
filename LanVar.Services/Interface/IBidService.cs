using System.Collections.Generic;
using System.Threading.Tasks;
using LanVar.Core.Entity;
using LanVar.DTO.DTO.request;
using LanVar.DTO.DTO.response;

public interface IBidService
{
    Task<Bid> GetBidById(long id);
    Task<List<Bid>> GetAllBids();
    Task CreateBid(BidDTORequest bidDTO);
    Task UpdateBid(BidDTORequest bidDTO);
    Task DeleteBid(long id);
    Task<BidDTOResponse> GetHighestBid(long auction_id);
}
