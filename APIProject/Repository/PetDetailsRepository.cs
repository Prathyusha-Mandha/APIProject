using APIProject.Data;
using APIProject.DTO;
using APIProject.Interface;
using APIProject.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace APIProject.Repository
{
    public class PetDetailsRepository : IPetDetails
    {
        private readonly PetContext _context;

        public PetDetailsRepository(PetContext context)
        {
            _context = context;
        }

        

        public async Task<List<PetDetails>> GetAllAsync()
        {
            return await _context.PetDetails
                .Include(p=> p.AdoptionRequests).ToListAsync();

        }



        public async Task<PetDetails?> GetByIdAsync(int id)
        {
            return await _context.PetDetails.Include(p => p.AdoptionRequests)
                                            .FirstOrDefaultAsync(p => p.PetId == id);
           
        }
        

        public async Task<PetDetails?> GetByNameAsync(string name)
        {
            return await _context.PetDetails.Include(p => p.AdoptionRequests)
                                            .FirstOrDefaultAsync(p => p.PetName == name);
        }

        public async Task<IEnumerable<PetDetails>> GetByCenterIdAsync(int centerId)
        {
            return await _context.PetDetails.Where(p => p.CenterId == centerId)
                                            .Include(p => p.AdoptionRequests)
                                            .ToListAsync();
        }

        async Task<PetDetails?> IPetDetails.GetByBreedAsync(string breed)
        {
            return await _context.PetDetails.Include(p => p.AdoptionRequests)
                                           .FirstOrDefaultAsync(p => p.Breed == breed);
        }
        async Task<PetDetails?> IPetDetails.GetByTypeAsync(string ptype)
        {
            return await _context.PetDetails.Include(p => p.AdoptionRequests)
                                           .FirstOrDefaultAsync(p => p.Type == ptype);
        }

        public async Task AddAsync(PetDetails pet)
        {
            _context.PetDetails.Add(pet);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateByIdAsync(int id, PetDetails pet)
        {
            var existingPet = await _context.PetDetails.FirstOrDefaultAsync(p => p.PetId == id);
            if (existingPet == null) return false;

            existingPet.PetName = pet.PetName;
            existingPet.Type = pet.Type;
            existingPet.Breed = pet.Breed;
            existingPet.Age = pet.Age;
            existingPet.Status = pet.Status;
            existingPet.CenterId = pet.CenterId;
            existingPet.CenterName = pet.CenterName;
            existingPet.Status = pet.Status;

            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateByNameAsync(string name, PetDetails pet)
        {
            var existingPet = await _context.PetDetails.FirstOrDefaultAsync(p => p.PetName == name);
            if (existingPet == null) return false;

            existingPet.PetName = pet.PetName;
            existingPet.Type = pet.Type;
            existingPet.Breed = pet.Breed;
            existingPet.Age = pet.Age;
            existingPet.Status = pet.Status;
            existingPet.CenterId = pet.CenterId;
            existingPet.CenterName = pet.CenterName;
            existingPet.Status = pet.Status;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var pet = await GetByIdAsync(id);
            if (pet == null) return false;

            _context.PetDetails.Remove(pet);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteByNameAsync(string name)
        {
            var pet = await GetByNameAsync(name);
            if (pet == null) return false;

            _context.PetDetails.Remove(pet);
            await _context.SaveChangesAsync();
            return true;
        }

        
    }
}
