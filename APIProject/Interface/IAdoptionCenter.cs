using APIProject.Model;

namespace APIProject.Interface
{
    public interface IAdoptionCenter
    {
        // Get all adoption centers
        Task<IEnumerable<AdoptionCenter>> GetAllAsync();

        // Get by CenterId
        Task<AdoptionCenter?> GetByIdAsync(int centerId);

        // Get by CenterName
        Task<AdoptionCenter?> GetByNameAsync(string centerName);

        // Add a new center
        Task AddAsync(AdoptionCenter center);

        // Update center
        Task<bool> UpdateByIdAsync(int id, AdoptionCenter center);
        Task<bool> UpdateByNameAsync(string name,AdoptionCenter center);

        // Delete by CenterId
        Task <bool>DeleteByIdAsync(int centerId);

        // Delete by CenterName
        Task<bool> DeleteByNameAsync(string centerName);
    }
}
