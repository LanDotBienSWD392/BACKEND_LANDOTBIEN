using System.Collections.Generic;
using System.Threading.Tasks;
using LanVar.Core.Entity;

namespace LanVar.Core.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(long id);
        void Update(User user);
        Task SaveChangesAsync();
        Task<bool> DeactivateUser(long id);
        Task<bool> ActivateUser(long id);
        Task<bool> DeleteUser(long id);
        Task<User> AddAsync(User user);
    }
}
