using System.Collections.Generic;
using System.Threading.Tasks;
using LanVar.Core.Entity;
using LanVar.DTO.DTO.request;
using LanVar.Service.DTO;
using LanVar.Service.DTO.request;

namespace LanVar.Service.Interface
{
    public interface IAccountService
    {
        Task<User> CreateUser(UserRegisterRequest userRegisterRequest);
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(long id);
        Task<User> UpdateUser(long id, UpdateUserDTORequest updateUserDTORequest);
        Task<bool> DeactivateUser(long id);
        Task<bool> ActivateUser(long id);
        Task<bool> DeleteUser(long id);
    }
}
