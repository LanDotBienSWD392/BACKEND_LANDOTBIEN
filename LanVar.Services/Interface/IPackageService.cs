using LanVar.Core.Entity;

namespace LanVar.Service.Interface;

public interface IPackageService
{
    Task<Package> AddPackage(Package package);
    Task<IEnumerable<Package>> GetAllRole(); 
    Task<Package> UpdatedPackage(long id, Package updatedPackage);
    Task<bool> DeletePackage(long id);
}