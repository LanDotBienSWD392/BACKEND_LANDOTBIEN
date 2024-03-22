using LanVar.Core.Entity;
using LanVar.DTO.DTO.request;

namespace LanVar.Service.Interface;

public interface IUserPackageService
{
    Task<User_Package> AddUserPackage(UserPackageDTORequest userPermission);
}