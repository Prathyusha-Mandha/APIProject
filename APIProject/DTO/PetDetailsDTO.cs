using APIProject.DTO;
using APIProject.Model;
using System.ComponentModel.DataAnnotations;

namespace APIProject.DTO
{
    public class PetDetailsDTO
    {
        public string? PetName { get; set; }
        public string? Type { get; set; }
        public string? Breed { get; set; }
        public int Age { get; set; }
        public int CenterId { get; set; }

        public string CenterName { get; set; }

        public string? Status { get; set; } = "Available";


    }
}


