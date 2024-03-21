using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LanVar.Core.Entity;
using LanVar.DTO.DTO.request;
using LanVar.DTO.DTO.response;
using LanVar.Repository.IRepository;

public class BidService : IBidService
{
    private readonly IBidRepository _repository;
    private readonly IAuctionRepository _auctionRepository;
    private readonly IMapper _mapper;

    public BidService(IBidRepository repository, IMapper mapper, IAuctionRepository auctionRepository)
    {
        _repository = repository;
        _auctionRepository = auctionRepository;
        _mapper = mapper;
    }

    public async Task<BidDTOResponse> GetHighestBid(long auctionId)
    {
        var highestBid = await _repository.GetHighestBid(auctionId);
        if (highestBid == null)
        {
            throw new Exception("No bids found.");
        }
        return _mapper.Map<BidDTOResponse>(highestBid);
    }

    public async Task<Bid> GetBidById(long id)
    {
        return await _repository.GetBidById(id);
    }

    public async Task<List<Bid>> GetAllBids()
    {
        return await _repository.GetAllBids();
    }

    public async Task CreateBid(BidDTORequest bidDTO)
    {
        // Get the highest bid
        var highestBid = await _repository.GetHighestBid(bidDTO.auction_id);

        // Check if there are any existing bids
        if (highestBid != null && bidDTO.bid <= highestBid.bid)
        {
            throw new Exception("Bid value must be higher than the current highest bid.");
        }

        // Get the auction by ID
        var auction = await _auctionRepository.GetByIdAsync(bidDTO.auction_id);

        // Check if the auction status is ACTIVE
        if (auction == null || auction.status != AuctionStatus.ACTIVE)
        {
            throw new Exception("Auction is not active.");
        }

        // Create the new bid
        var bid = _mapper.Map<Bid>(bidDTO);
        bid.bid_time = DateTime.Now; // Set bid time here
        await _repository.CreateBid(bid);
    }

    public async Task UpdateBid(BidDTORequest bidDTO)
    {
        var bid = _mapper.Map<Bid>(bidDTO);
        await _repository.UpdateBid(bid);
    }

    public async Task DeleteBid(long id)
    {
        await _repository.DeleteBid(id);
    }
}
