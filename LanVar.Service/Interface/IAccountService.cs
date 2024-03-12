using LanVar.Core.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LanVar.Service.Interface
{
    public interface IAccountService
    {
        Task<User> AddUser(User user);
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(long id);
        Task<User> UpdateUser(long id, User updatedUser);
        Task<User> DeleteUser(long id);
        Task<bool> DeactivateUser(long id);
        Task<bool> ActivateUser(long id);
    }
}
