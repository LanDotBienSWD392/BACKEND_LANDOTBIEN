using System.Threading.Tasks;
using AutoMapper;
using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LanVar.Insfrastructure.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly IMapper _mapper;

        public UserRepository(MyDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<User> AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            return user;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(long id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.id == id);
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeactivateUser(long id)
        {
            var userToDeactivate = await _context.Users.FindAsync(id);
            if (userToDeactivate == null)
            {
                return false; // User not found
            }

            userToDeactivate.Status = false;
            _context.Users.Update(userToDeactivate);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ActivateUser(long id)
        {
            var userToActivate = await _context.Users.FindAsync(id);
            if (userToActivate == null)
            {
                return false; // User not found
            }

            userToActivate.Status = true;
            _context.Users.Update(userToActivate);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteUser(long id)
        {
            var userToDelete = await _context.Users.FindAsync(id);
            if (userToDelete == null)
            {
                return false; // User not found
            }

            _context.Users.Remove(userToDelete);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
