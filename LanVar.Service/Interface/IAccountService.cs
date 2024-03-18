using System.Collections.Generic;
using System.Threading.Tasks;
using LanVar.Core.Entity;
using LanVar.DTO.DTO.request;
using LanVar.DTO.request;
using LanVar.Service.DTO;
using LanVar.Service.DTO.request;

namespace LanVar.Service.Interface
{
    public interface IAccountService
    {
        Task<User> CreateUser(CreateAccountDTORequest createAccountRequest);
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(long id);
        Task<User> UpdateUser(long id, UpdateUserDTORequest updateUserDTORequest);
        Task<bool> DeactivateUser(long id);
        Task<bool> ActivateUser(long id);
        Task<bool> DeleteUser(long id);
        Task<IEnumerable<User>> GetAllStaffUsers();
        Task<User> CreateStaffUser(CreateAccountDTORequest createAccountRequest);
        Task<User> UpdateStaffUser(long id, UpdateUserDTORequest updateUserDTORequest);
        Task<bool> DeleteStaffUser(long id);
        Task<User> PurchasePackage(long userId, long packageId);
    }
}
