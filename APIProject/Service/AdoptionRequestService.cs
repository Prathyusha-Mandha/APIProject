using APIProject.Interface;
using APIProject.Model;
using Azure.Core;
using Microsoft.EntityFrameworkCore;

namespace APIProject.Service
{
    public class AdoptionRequestService
    {
        private readonly IAdoptionRequest _repo;
        private readonly IPetDetails _petRepo;
        private readonly IUser _UserRepo;

        public AdoptionRequestService(IAdoptionRequest repo, IPetDetails petRepo)
        {
            _repo = repo;
            _petRepo = petRepo;
        }

        public async Task<IEnumerable<AdoptionRequest>> GetAllRequestsAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<AdoptionRequest?> GetByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }
        public async Task<AdoptionRequest?> GetByUserIdAsync(int userId)
        {
            return await _repo.GetByUserIdAsync(userId);
        }

        public async Task<AdoptionRequest?> GetByUserNameAsync(string name)
        {
            return await _repo.GetByUserNameAsync(name);
        }
        public async Task<AdoptionRequest?> GetByPetIdAsync(int petId)
        {
            return await _repo.GetByPetIdAsync(petId);
        }
        public async Task<AdoptionRequest?> GetByPetNameAsync(string petname)
        {
            
            return await _repo.GetByPetNameAsync(petname);
        }


        public async Task AddAsync(AdoptionRequest request)
        {
            await _repo.AddAsync(request);
        }
        public async Task<bool> UpdateByRequestIdAsync(int reqid, AdoptionRequest request)
        {
           return await _repo.UpdateByRequestIdAsync(reqid, request);
        }
        public async Task<bool> UpdateByUserIdAsync(int userId, AdoptionRequest request)
        {
           return await _repo.UpdateByUserIdAsync(userId, request);
        }
        public async Task<bool> UpdateByUserNameAsync(string userName, AdoptionRequest request)
        {
            return await _repo.UpdateByUserNameAsync(userName, request);
        }
        public async Task<bool> UpdateByPetIdAsync(int petId, AdoptionRequest request)
        {
            return await _repo.UpdateByPetIdAsync(petId, request);
        }
        public async Task<bool> UpdateByPetNameAsync(string petName, AdoptionRequest request)
        {
            return await _repo.UpdateByPetNameAsync(petName, request);
        }
        public async Task<bool> DeleteByUserIdAsync(int userId)
        {
            return await _repo.DeleteByUserIdAsync(userId);
        }
        public async Task<bool> DeleteByUserNameAsync(string userName)
        {
            return await _repo.DeleteByUserNameAsync(userName);
        }
        public async Task<bool> DeleteByPetIdAsync(int petId)
        {
           return await _repo.DeleteByPetIdAsync(petId);
        }
        public async Task<bool> DeleteByPetNameAsync(string petName)
        {
           return await _repo.DeleteByPetNameAsync(petName);
        }
        public async Task<bool> DeleteByRequestIdAsync(int requestId)
        {
            return await _repo.DeleteByRequestIdAsync(requestId);
        }
    }
}

