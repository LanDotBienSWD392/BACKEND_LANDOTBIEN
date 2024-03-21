using System;
using System.Linq.Expressions;
using LanVar.Core.Entity;

namespace LanVar.Core.Interfaces
{
    public interface IRoomRegistrationsRepository
    {
        Task<RoomRegistrations> GetByIdAsync(long id);
        Task<List<RoomRegistrations>> GetByAuctionIdAsync(long auctionId);
        Task AddAsync(RoomRegistrations roomRegistrations);
        Task UpdateAsync(RoomRegistrations roomRegistrations);
        Task DeleteAsync(RoomRegistrations roomRegistrations);
        Task<List<RoomRegistrations>> GetByFilterAsync(Expression<Func<RoomRegistrations, bool>> filter);
    }   
}

