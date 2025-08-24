using APIProject.Model;

namespace APIProject.Interface
{
    public interface IPetDetails
    {
        Task<List<PetDetails>> GetAllAsync();

        // Get pet by Id, Name, or Breed
        Task<PetDetails?> GetByIdAsync(int id);
        Task<PetDetails?> GetByNameAsync(string name);
        Task<PetDetails?> GetByBreedAsync(string breed);
        Task<PetDetails?> GetByTypeAsync(string type);

        // Get pets by Center
        Task<IEnumerable<PetDetails>> GetByCenterIdAsync(int centerId);

        // Add new pet
        Task AddAsync(PetDetails pet);

        // Update pet by Id, Name, or Breed
        Task <bool>UpdateByIdAsync(int id,PetDetails pet); 
        Task <bool>UpdateByNameAsync(string name,PetDetails pet);

        // Delete pet by Id, Name, or Breed
        Task <bool>DeleteByIdAsync(int id);
        Task<bool> DeleteByNameAsync(string name);
    }
}
