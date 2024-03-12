using LanVar.Core.Entity;
using LanVar.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanVar.Service.Implementation
{
    public class AccountService : IAccountService
    {
        private readonly MyDbContext _myDbContext;

        public AccountService(MyDbContext dbContext)
        {
            _myDbContext = dbContext;
        }

        public async Task<User> AddUser(User user)
        {
            _myDbContext.Users.Add(user);
            await _myDbContext.SaveChangesAsync();
            return user;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _myDbContext.Users.ToListAsync();
        }

        public async Task<User> GetUserById(long id)
        {
            return await _myDbContext.Users.FindAsync(id);
        }

        public async Task<User> UpdateUser(long id, User updatedUser)
        {
            var existingUser = await _myDbContext.Users.FindAsync(id);

            if (existingUser == null)
            {
                // Handle not found scenario, có thể trả về null hoặc thực hiện xử lý phù hợp
                return null;
            }

            _myDbContext.Entry(existingUser).CurrentValues.SetValues(updatedUser);

            await _myDbContext.SaveChangesAsync();
            return existingUser;
        }

        public async Task<bool> DeactivateUser(long id)
        {
            var user = await _myDbContext.Users.FindAsync(id);

            if (user == null)
            {
                // Handle not found scenario
                return false;
            }

            user.Status = false; // Assuming 'Status' is a property representing user's active status
            await _myDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ActivateUser(long id)
        {
            var user = await _myDbContext.Users.FindAsync(id);

            if (user == null)
            {
                // Handle not found scenario
                return false;
            }

            user.Status = true; // Assuming 'Status' is a property representing user's active status
            await _myDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<User> DeleteUser(long id)
        {
            var user = await _myDbContext.Users.FindAsync(id);

            if (user == null)
            {
                // Handle not found scenario
                return null;
            }

            _myDbContext.Users.Remove(user);
            await _myDbContext.SaveChangesAsync();
            return user;
        }
    }
}
