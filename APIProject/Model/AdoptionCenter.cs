using System.ComponentModel.DataAnnotations;

namespace APIProject.Model
{
    public class AdoptionCenter
    {
        [Key]
        public int CenterId { get; set; }
        [Required, MaxLength(50)]
        public string? CenterName { get; set; }
        [Required, MaxLength(100)]
        public string? Location { get; set; }
        [Required, MaxLength(15)]
        public string? ContactNumber { get; set; }
        [Required, MaxLength(100)]
        public string? Email { get; set; }
        public List<PetDetails> Pets { get; set; }
    }
}
