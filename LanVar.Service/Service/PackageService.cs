using System.Net;
using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using LanVar.Service.Interface;
using Tools.Tools;

namespace LanVar.Service.Service;

public class PackageService : IPackageService
{
    private readonly IPackageRepository _packageRepository;
    public PackageService(IPackageRepository packageRepository)
    {
        _packageRepository = packageRepository;
    }

    public async Task<Package> AddPackage(Package package)
    {
        string id = package.PackageName.ToString();
        if (string.IsNullOrEmpty(id))
        {
            throw new CustomException.InvalidDataException(HttpStatusCode.BadRequest.ToString(),"Package name invalid");
            
        }
        IEnumerable<Package> duplicatePackage =
            await _packageRepository.GetByFilterAsync(x => x.PackageName.Equals(id));

        if (duplicatePackage.Any())
        {
            throw new CustomException.InvalidDataException(HttpStatusCode.BadRequest.ToString(),"Package name exist");
        }

        return await _packageRepository.Add(package);
    }

    public async Task<IEnumerable<Package>> GetAllRole()
    {
        return await _packageRepository.GetAllAsync();
    }

    public async Task<Package> UpdatedPackage(long id, Package updatedPackage)
    {
        var existingRole = await _packageRepository.GetById(id);
        if (existingRole == null)
        {
            throw new CustomException.InvalidDataException(HttpStatusCode.NotFound.ToString(), "Role not found");
        }

        // Update the properties of the existing role
        
        existingRole.Package_Description = updatedPackage.Package_Description;
        existingRole.PackageName = updatedPackage.PackageName;
        existingRole.StartDay = updatedPackage.StartDay;
        existingRole.EndDay = updatedPackage.EndDay;
        existingRole.Status = updatedPackage.Status;
            

        // Save the changes
        return await _packageRepository.Update(existingRole);
    }

    public async Task<bool> DeletePackage(long id)
    {
        // Check if the role with the given id exists
        var existingPackage = await _packageRepository.GetById(id);
        if (existingPackage == null)
        {
            throw new CustomException.InvalidDataException(HttpStatusCode.NotFound.ToString(), "Package not found");
        }

        await _packageRepository.Delete(id);
        return true;
    }
}