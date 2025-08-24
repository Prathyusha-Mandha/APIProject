using APIProject.Model;
using Microsoft.EntityFrameworkCore;

namespace APIProject.Data
{
    public class PetContext : DbContext
    {
        public PetContext(DbContextOptions<PetContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<PetDetails> PetDetails { get; set; }
        public DbSet<AdoptionRequest> AdoptionRequests { get; set; }
        public DbSet<AdoptionCenter> AdoptionCenters { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<PetDetails>()
                .HasOne(p => p.Center)
                .WithMany(c => c.Pets)
                .HasForeignKey(p => p.CenterId)
                .OnDelete(DeleteBehavior.Cascade);

           
            modelBuilder.Entity<PetDetails>()
                .HasMany(p => p.AdoptionRequests)
                .WithOne()
                .HasForeignKey(r => r.PetId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany<AdoptionRequest>()
                .WithOne()
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, Username = "Admin", UserEmail = "admin@test.com", Password = "admin123", Role = "Admin" },
                new User { UserId = 2, Username = "John", UserEmail = "john@test.com", Password = "john123", Role = "User" }
            );

            
            modelBuilder.Entity<AdoptionCenter>().HasData(
                new AdoptionCenter { CenterId = 1, CenterName = "Happy Paws", Location = "City A", ContactNumber = "1234567890", Email = "happypaws@test.com" },
                new AdoptionCenter { CenterId = 2, CenterName = "Safe Haven", Location = "City B", ContactNumber = "0987654321", Email = "safehaven@test.com" }
            );

            
            modelBuilder.Entity<PetDetails>().HasData(
                new PetDetails { PetId = 1, PetName = "Bella", Type = "Dog", Breed = "Labrador", Age = 2, Status = "Available", CenterId = 1,CenterName = "Happy Paws"},
                new PetDetails { PetId = 2, PetName = "Milo", Type = "Cat", Breed = "Persian", Age = 1, Status = "Available", CenterId = 1, CenterName = "Happy Paws" }
            );

            
            modelBuilder.Entity<AdoptionRequest>().HasData(
                new AdoptionRequest { RequestId = 1, UserId = 2, UserName = "John", PetId = 1, PetName = "Bella" }
            );
        }
    }
}
