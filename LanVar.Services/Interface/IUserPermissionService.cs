using LanVar.Core.Entity;

namespace LanVar.Service.Interface;

public interface IUserPermissionService
{
    Task<UserPermission> AddUserPermission(UserPermission userPermission);
    Task<IEnumerable<UserPermission>> GetAllRole(); 
    Task<UserPermission> UpdateRole(long id, UserPermission updatedUserPermission);
    Task<bool> DeleteRole(long id);

}