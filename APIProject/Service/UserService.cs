using APIProject.Interface;
using APIProject.Model;

namespace APIProject.Service
{
    public class UserService
    {
        private readonly IUser _repo;

        public UserService(IUser repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<User?> GetUserByNameAsync(string name)
        {
            return await _repo.GetByNameAsync(name);
        }

        public async Task AddUserAsync(User user)
        {
            await _repo.AddAsync(user);
        }

        public async Task UpdateByIdAsync(int id,User user)
        {
            await _repo.UpdateByIdAsync(id, user);
        }


        public async Task UpdateByNameAsync(string name, User user)
        {
            await _repo.UpdateByNameAsync(name, user);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _repo.DeleteByIdAsync(id);
        }

        public async Task DeleteUserAsync(string name)
        {
            await _repo.DeleteByNameAsync(name);
        }

        public async Task<string?> GetRoleByIdAsync(int id)
        {
            return await _repo.GetRoleByIdAsync(id);
        }

        public async Task<bool> IsAdminAsync(int id)
        {
            return await _repo.IsAdminAsync(id);
        }

        public async Task<bool> IsUserAsync(int id)
        {
            return await _repo.IsUserAsync(id);
        }
    }
}
