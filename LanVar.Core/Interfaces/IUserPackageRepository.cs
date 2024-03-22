using LanVar.Core.Entity;

namespace LanVar.Core.Interfaces;

public interface IUserPackageRepository
{
    Task<User_Package> GetByIdAsync(long id);
}