using System.Threading.Tasks;
using AutoMapper;
using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LanVar.Insfrastructure.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        
        private readonly MyDbContext _dbContext;
        protected DbSet<User> _users;

        public UserRepository(MyDbContext context) : base(context)
        {
            _dbContext = context;
            _users = _context.Set<User>();
        }

        public async Task<User> AddAsync(User user)
        {
            _context.Set<User>().Add(user);
            await _context.SaveChangesAsync();
            return user;

            //_context.Set<TEntity>().Add(entity);
            //await _context.SaveChangesAsync(); // Save changes asynchronously
            //return entity;
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

            userToDeactivate.status = false;
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

            userToActivate.status = true;
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

        public async Task<IEnumerable<User>> GetAllStaffUsers()
        {
            return await _context.Users.Where(u => u.Permission_id == 3).ToListAsync();
        }
    }
}
