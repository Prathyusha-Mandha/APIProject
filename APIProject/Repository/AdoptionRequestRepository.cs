using APIProject.Data;
using APIProject.Interface;
using APIProject.Model;
using Microsoft.EntityFrameworkCore;

namespace APIProject.Repository
{
    public class AdoptionRequestRepository : IAdoptionRequest
    {
        private readonly PetContext _context;

        public AdoptionRequestRepository(PetContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AdoptionRequest>> GetAllAsync()
        {
            return await _context.AdoptionRequests.ToListAsync();
        }

        public async Task<AdoptionRequest?> GetByIdAsync(int id)
        {
            return await _context.AdoptionRequests.FindAsync(id);
        }

        public async Task<AdoptionRequest?> GetByUserIdAsync(int userId)
        {
            return await _context.AdoptionRequests.FirstOrDefaultAsync(r => r.UserId == userId);
        }
        public async Task<AdoptionRequest?> GetByUserNameAsync(string userName)
        {
            return await _context.AdoptionRequests
                                 .FirstOrDefaultAsync(r => r.UserName == userName);
        }
        public async Task<AdoptionRequest?> GetByPetIdAsync(int petId)
        {
            return await _context.AdoptionRequests
                                 .FirstOrDefaultAsync(r => r.PetId == petId);
        }
        public async Task<AdoptionRequest?> GetByPetNameAsync(string petName)
        {
            return await _context.AdoptionRequests
                                 .FirstOrDefaultAsync(r => r.PetName == petName);
        }
        public async Task AddAsync(AdoptionRequest request)
        {
            _context.AdoptionRequests.Add(request);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateByRequestIdAsync(int reqid, AdoptionRequest request)
        {
            var existing = await _context.AdoptionRequests.FindAsync(reqid);
            if (existing == null) return false;

            existing.Status = request.Status;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateByUserIdAsync(int userId, AdoptionRequest request)
        {
            var requests = await _context.AdoptionRequests
                                         .Where(r => r.UserId == userId)
                                         .ToListAsync();
            if (!requests.Any()) return false;

            foreach (var r in requests)
            {
                r.Status = request.Status;
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateByUserNameAsync(string userName, AdoptionRequest request)
        {
            var requests = await _context.AdoptionRequests
                                         .Where(r => r.UserName == userName)
                                         .ToListAsync();
            if (!requests.Any()) return false;

            foreach (var r in requests)
            {
                r.Status = request.Status;
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateByPetIdAsync(int petId, AdoptionRequest request)
        {
            var requests = await _context.AdoptionRequests
                                         .Where(r => r.PetId == petId)
                                         .ToListAsync();
            if (!requests.Any()) return false;

            foreach (var r in requests)
            {
                r.Status = request.Status;
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateByPetNameAsync(string petName, AdoptionRequest request)
        {
            var requests = await _context.AdoptionRequests
                                         .Where(r => r.PetName == petName) 
                                         .ToListAsync();
            if (!requests.Any()) return false;

            foreach (var r in requests)
            {
                r.Status = request.Status;
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteByRequestIdAsync(int requestId)
        {
            var request = await _context.AdoptionRequests.FindAsync(requestId);
            if (request == null) return false;

            _context.AdoptionRequests.Remove(request);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteByUserIdAsync(int userId)
        {
            var requests = await _context.AdoptionRequests
                                         .Where(r => r.UserId == userId)
                                         .ToListAsync();
            if (!requests.Any()) return false;

            _context.AdoptionRequests.RemoveRange(requests);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteByUserNameAsync(string userName)
        {
            var requests = await _context.AdoptionRequests
                                         .Where(r => r.UserName == userName)
                                         .ToListAsync();
            if (!requests.Any()) return false;

            _context.AdoptionRequests.RemoveRange(requests);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteByPetIdAsync(int petId)
        {
            var requests = await _context.AdoptionRequests
                                         .Where(r => r.PetId == petId)
                                         .ToListAsync();
            if (!requests.Any()) return false;

            _context.AdoptionRequests.RemoveRange(requests);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteByPetNameAsync(string petName)
        {
            var requests = await _context.AdoptionRequests
                                         .Where(r => r.PetName == petName) 
                                         .ToListAsync();
            if (!requests.Any()) return false;

            _context.AdoptionRequests.RemoveRange(requests);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
