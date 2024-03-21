using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanVar.Core.Entity;
using Microsoft.EntityFrameworkCore;

public class BidRepository : IBidRepository
{
    private readonly MyDbContext _context;

    public BidRepository(MyDbContext context)
    {
        _context = context;
    }
    public async Task<Bid> GetHighestBid(long auctionId)
    {
        return await _context.Bids
            .Include(b => b.auction)
            .Include(b => b.user)
            .Where(b => b.auction_id == auctionId)
            .OrderByDescending(b => b.bid)
            .FirstOrDefaultAsync();
    }

    public async Task<Bid> GetBidById(long id)
    {
        return await _context.Bids.FindAsync(id);
    }

    public async Task<List<Bid>> GetAllBids()
    {
        return await _context.Bids.ToListAsync();
    }

    public async Task CreateBid(Bid bid)
    {
        _context.Bids.Add(bid);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateBid(Bid bid)
    {
        _context.Entry(bid).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteBid(long id)
    {
        var bid = await _context.Bids.FindAsync(id);
        _context.Bids.Remove(bid);
        await _context.SaveChangesAsync();
    }
}
