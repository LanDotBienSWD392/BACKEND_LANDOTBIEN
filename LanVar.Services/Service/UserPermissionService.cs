using System.Net;
using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using LanVar.Service.Interface;
using Microsoft.EntityFrameworkCore;
using Tools.Tools;

namespace LanVar.Service.Service;

public class UserPermissionService : IUserPermissionService
{
    private readonly IGenericRepository<UserPermission> _userPermissionRepository;

    public UserPermissionService(
        IGenericRepository<UserPermission> userPermissionRepository
        )
    {
        _userPermissionRepository = userPermissionRepository;
    }
    public async Task<UserPermission> AddUserPermission(UserPermission userPermission)
    {
        string id = userPermission.role.ToString();
        if (string.IsNullOrEmpty(id))
        {
            throw new CustomException.InvalidDataException(HttpStatusCode.BadRequest.ToString(),"Invalid Role");
        }

        IEnumerable<UserPermission> duplicateRole =
            await _userPermissionRepository.GetByFilterAsync(x => x.role.Equals(id));
        if (duplicateRole.Any())
        {
            throw new CustomException.InvalidDataException(HttpStatusCode.BadRequest.ToString(),"Dupliacte Role");
        }
        return await _userPermissionRepository.Add(userPermission);
    }

    public async Task<IEnumerable<UserPermission>> GetAllRole()
    {
        return await _userPermissionRepository.GetAllAsync();
    }

    public async Task<UserPermission> UpdateRole(long id, UserPermission updatedUserPermission)
    {
        var existingRole = await _userPermissionRepository.GetById(id);
        if (existingRole == null)
        {
            throw new CustomException.InvalidDataException(HttpStatusCode.NotFound.ToString(), "Role not found");
        }

        // Update the properties of the existing role
        existingRole.role = updatedUserPermission.role;

        // Save the changes
        return await _userPermissionRepository.Update(existingRole);
    }

    public async Task<bool> DeleteRole(long id)
    {
        // Check if the role with the given id exists
        var existingRole = await _userPermissionRepository.GetById(id);
        if (existingRole == null)
        {
            throw new CustomException.InvalidDataException(HttpStatusCode.NotFound.ToString(), "Role not found");
        }

        await _userPermissionRepository.Delete(id);
        return true;
    }
}