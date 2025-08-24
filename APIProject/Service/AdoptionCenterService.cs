using APIProject.Interface;
using APIProject.Model;

namespace APIProject.Service
{
    public class AdoptionCenterService
    {
        private readonly IAdoptionCenter _repo;

        public AdoptionCenterService(IAdoptionCenter repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<AdoptionCenter>> GetAllCentersAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<AdoptionCenter?> GetCenterByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<AdoptionCenter?> GetCenterByNameAsync(string name)
        {
            return await _repo.GetByNameAsync(name);
        }

        public async Task AddCenterAsync(AdoptionCenter center)
        {
            await _repo.AddAsync(center);
        }

        public async Task<bool> UpdateCenterByIdAsync(int id, AdoptionCenter center)
        {
            return await _repo.UpdateByIdAsync(id, center);
        }

        public async Task<bool> UpdateCenterByNameAsync(string name, AdoptionCenter center)
        {
            return await _repo.UpdateByNameAsync(name, center);
        }

        public async Task<bool> DeleteCenterByIdAsync(int id)
        {
            return await _repo.DeleteByIdAsync(id);
        }

        public async Task<bool> DeleteCenterByNameAsync(string name)
        {
            return await _repo.DeleteByNameAsync(name);
        }

    }
}
