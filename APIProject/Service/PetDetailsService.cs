using APIProject.Interface;
using APIProject.Model;

namespace APIProject.Service
{
    public class PetDetailsService
    {
        private readonly IPetDetails _repo;

        public PetDetailsService(IPetDetails repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<PetDetails>> GetAllPetsAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<PetDetails?> GetPetByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<PetDetails?> GetPetByNameAsync(string name)
        {
            return await _repo.GetByNameAsync(name);
        }

        public async Task<PetDetails?> GetPetByBreedAsync(string breed)
        {
            return await _repo.GetByBreedAsync(breed);
        }
        public async Task<PetDetails?> GetPetByTypeAsync(string type)
        {
            return await _repo.GetByTypeAsync(type);
        }

        public async Task AddPetAsync(PetDetails pet)
        {
            await _repo.AddAsync(pet);
        }

        public async Task<bool> UpdateByIdAsync(int id, PetDetails pet)
        {
            return await _repo.UpdateByIdAsync(id, pet);
        }

        public async Task<bool> UpdateByNameAsync(string name, PetDetails pet)
        {
            return await _repo.UpdateByNameAsync(name, pet);
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            return await _repo.DeleteByIdAsync(id);
        }

        public async Task<bool> DeleteByNameAsync(string name)
        {
            return await _repo.DeleteByNameAsync(name);
        }
    }
}

