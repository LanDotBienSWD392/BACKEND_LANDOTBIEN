using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LanVar.Insfrastructure.Repository;

public class UserPackageRepository : IUserPackageRepository
{
    private readonly MyDbContext _context;

    public UserPackageRepository(MyDbContext context)
    {
        _context = context;
    }

    public async Task<User_Package> GetByIdAsync(long id)
    {
        return await _context.UserPackages.FirstOrDefaultAsync(x => x.user_id == id && x.status == PackageStatus.Active);
    }

}