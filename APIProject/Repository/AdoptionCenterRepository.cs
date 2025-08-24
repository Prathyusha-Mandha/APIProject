using APIProject.Data;
using APIProject.Interface;
using APIProject.Model;
using Microsoft.EntityFrameworkCore;

namespace APIProject.Repository
{
    public class AdoptionCenterRepository : IAdoptionCenter
    {
        private readonly PetContext _context;

        public AdoptionCenterRepository(PetContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AdoptionCenter>> GetAllAsync()
        {
            return await _context.AdoptionCenters
            .Include(c => c.Pets)
                .ThenInclude(p => p.AdoptionRequests) 
            .ToListAsync();
        }

        public async Task<AdoptionCenter?> GetByIdAsync(int id)
        {
            return await _context.AdoptionCenters.Include(c => c.Pets)
                                                 .FirstOrDefaultAsync(c => c.CenterId == id);
        }

        public async Task<AdoptionCenter?> GetByNameAsync(string centerName)
        {
            return await _context.AdoptionCenters
                                 .Include(c => c.Pets) 
                                 .FirstOrDefaultAsync(c => c.CenterName == centerName);
        }
        public async Task AddAsync(AdoptionCenter center)
        {
            _context.AdoptionCenters.Add(center);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateByIdAsync(int id, AdoptionCenter center)
        {
            var existing = await _context.AdoptionCenters.FindAsync(id);
            if (existing == null) return false;

            existing.CenterName = center.CenterName;
            existing.Location = center.Location;
            existing.ContactNumber = center.ContactNumber;
            existing.Email = center.Email;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateByNameAsync(string name, AdoptionCenter center)
        {
            var existing = await _context.AdoptionCenters
                                         .FirstOrDefaultAsync(c => c.CenterName == name);
            if (existing == null) return false;

            existing.CenterName = center.CenterName;
            existing.Location = center.Location;
            existing.ContactNumber = center.ContactNumber;
            existing.Email = center.Email;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var existing = await _context.AdoptionCenters.FindAsync(id);
            if (existing == null) return false;

            _context.AdoptionCenters.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteByNameAsync(string name)
        {
            var existing = await _context.AdoptionCenters
                                         .FirstOrDefaultAsync(c => c.CenterName == name);
            if (existing == null) return false;

            _context.AdoptionCenters.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
