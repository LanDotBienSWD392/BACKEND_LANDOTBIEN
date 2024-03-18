using System.Collections.Generic;
using System.Threading.Tasks;
using LanVar.Core.Entity;

public interface IBidRepository
{
    Task<Bid> GetBidById(long id);
    Task<List<Bid>> GetAllBids();
    Task CreateBid(Bid bid);
    Task UpdateBid(Bid bid);
    Task DeleteBid(long id);
    Task<Bid> GetHighestBid(long auctionId);
}
