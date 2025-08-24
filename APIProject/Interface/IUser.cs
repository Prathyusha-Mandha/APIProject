using APIProject.Model;

namespace APIProject.Interface
{
    public interface IUser
    {
        Task<IEnumerable<User>> GetAllAsync();

        // Get user by Id or Name
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetByNameAsync(string name);

        // Add new user
        Task AddAsync(User user);

        // Update user by Id or Name
        Task UpdateByIdAsync(int id,User user);                 
        Task UpdateByNameAsync(string name,User user);

        // Delete user by Id or Name
        Task DeleteByIdAsync(int id);
        Task DeleteByNameAsync(string name);

        Task<string?> GetRoleByIdAsync(int id);
        Task<bool> IsAdminAsync(int id);
        Task<bool> IsUserAsync(int id);
    }
}
