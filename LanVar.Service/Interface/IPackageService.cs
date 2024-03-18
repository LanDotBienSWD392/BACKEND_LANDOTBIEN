using LanVar.Core.Entity;

namespace LanVar.Service.Interface;

public interface IPackageService
{
    Task<Package> AddPackage(Package package);
    Task<IEnumerable<Package>> GetAllPackage(); 
    Task<Package> GetPackageById(long id);
    Task<Package> UpdatedPackage(long id, Package updatedPackage);
    Task<bool> DeletePackage(long id);
}