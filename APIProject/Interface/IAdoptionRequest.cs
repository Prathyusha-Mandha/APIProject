using APIProject.Model;

namespace APIProject.Interface
{
    public interface IAdoptionRequest
    {
        Task<IEnumerable<AdoptionRequest>> GetAllAsync();

        // Get by RequestId
        Task<AdoptionRequest?> GetByIdAsync(int requestId);

        // Get requests by UserId
        Task<AdoptionRequest?>GetByUserIdAsync(int userId);

        //Get requests by UserName
        Task<AdoptionRequest?> GetByUserNameAsync(string userName);

        // Get requests by PetId
        Task<AdoptionRequest?> GetByPetIdAsync(int petId);
        // Get requests by PetName
        Task<AdoptionRequest?> GetByPetNameAsync(string petName);

        // Add a new request
        Task AddAsync(AdoptionRequest request);

        // Update request
        Task<bool> UpdateByRequestIdAsync(int reqid,AdoptionRequest request);

        Task<bool> UpdateByUserIdAsync(int userId,AdoptionRequest request);

        Task<bool> UpdateByUserNameAsync(string userName,AdoptionRequest request);

        // Delete all requests by PetId
        Task<bool> UpdateByPetIdAsync(int petId, AdoptionRequest request);

        Task<bool> UpdateByPetNameAsync(string petName, AdoptionRequest request);


        // Delete all requests by UserId
        Task<bool> DeleteByUserIdAsync(int userId);

        Task<bool> DeleteByUserNameAsync(string userName);

        // Delete all requests by PetId
        Task<bool> DeleteByPetIdAsync(int petId);

        Task<bool> DeleteByPetNameAsync(string petName);

        Task<bool> DeleteByRequestIdAsync(int requestId);

    }
}
