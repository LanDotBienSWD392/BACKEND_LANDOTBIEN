using System.Net;
using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using LanVar.Service.Interface;
using Tools.Tools;

namespace LanVar.Service.Service;

public class PackageService : IPackageService
{
    private readonly IGenericRepository<Package> _packageRepository;
    public PackageService(IGenericRepository<Package> packageRepository)
    {
        _packageRepository = packageRepository;
    }

    public async Task<Package> AddPackage(Package package)
    {
        string id = package.packageName.ToString();
        if (string.IsNullOrEmpty(id))
        {
            throw new CustomException.InvalidDataException(HttpStatusCode.BadRequest.ToString(),"Package name invalid");
            
        }
        IEnumerable<Package> duplicatePackage =
            await _packageRepository.GetByFilterAsync(x => x.packageName.Equals(id));

        if (duplicatePackage.Any())
        {
            throw new CustomException.InvalidDataException(HttpStatusCode.BadRequest.ToString(),"Package name exist");
        }

        return await _packageRepository.Add(package);
    }

    public async Task<IEnumerable<Package>> GetAllPackage()
    {
        return await _packageRepository.GetAllAsync();
    }

    public async Task<Package> UpdatedPackage(long id, Package updatedPackage)
    {
        var existingRole = await _packageRepository.GetById(id);
        if (existingRole == null)
        {
            throw new CustomException.InvalidDataException(HttpStatusCode.NotFound.ToString(), "Package not found");
        }

        // Update the properties of the existing role
        
        existingRole.package_Description = updatedPackage.package_Description;
        existingRole.packageName = updatedPackage.packageName;
        existingRole.startDay = updatedPackage.startDay;
        existingRole.endDay = updatedPackage.endDay;
        existingRole.status = updatedPackage.status;
            

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

    public async Task<Package> GetPackageById(long id)
    {
        return await _packageRepository.GetById(id);
    }
}