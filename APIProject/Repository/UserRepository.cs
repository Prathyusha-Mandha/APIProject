using APIProject.Data;
using APIProject.Interface;
using APIProject.Model;
using Microsoft.EntityFrameworkCore;

namespace APIProject.Repository
{
    public class UserRepository : IUser
    {
        private readonly PetContext _context;

        public UserRepository(PetContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User?> GetByNameAsync(string name)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == name);
        }

        public async Task AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateByIdAsync(int id,User user)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
            if (existingUser != null)
            {
                existingUser.Username = user.Username;
                existingUser.UserEmail = user.UserEmail;
                existingUser.Password = user.Password;
                await _context.SaveChangesAsync();
            }
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateByNameAsync(string name, User user)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Username == name);
            if (existingUser != null)
            {
                existingUser.Username = user.Username;
                existingUser.UserEmail = user.UserEmail;
                existingUser.Password = user.Password;
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteByIdAsync(int id)
        {
            var user = await GetByIdAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteByNameAsync(string name)
        {
            var user = await GetByNameAsync(name);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
        
        public async Task<string?> GetRoleByIdAsync(int id)
        {
            return await _context.Users
                .AsNoTracking()
                .Where(u => u.UserId == id)
                .Select(u => u.Role)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> IsAdminAsync(int id)
        {
            var role = await GetRoleByIdAsync(id);
            return string.Equals(role, "Admin", StringComparison.OrdinalIgnoreCase);
        }

        public async Task<bool> IsUserAsync(int id)
        {
            var role = await GetRoleByIdAsync(id);
            return string.Equals(role, "User", StringComparison.OrdinalIgnoreCase);
        }
    }
}
