using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIProject.Model
{
    public class PetDetails
    {
        [Key]
        public int PetId { get; set; }
        [Required,MaxLength(20)]
        public string? PetName { get; set; }
        [Required,MaxLength(10)]
        public string? Type { get; set; }
        [Required,MaxLength(20)]
        public string? Breed { get; set; }
        [Range(1,10)]
        public int Age { get; set; }
        [Required,MaxLength(10)]
        public string? Status { get; set; } 
        [Required]
        public int CenterId { get; set; }
        [Required,MaxLength(10)]
        public string CenterName { get; set; }  

        public AdoptionCenter Center { get; set; }

        public List<AdoptionRequest> AdoptionRequests { get; set; }

        

    }
}
