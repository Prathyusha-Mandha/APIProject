using System.ComponentModel.DataAnnotations;

namespace APIProject.Model
{
    public class AdoptionRequest
    {
        [Key]
        public int RequestId { get; set; }

        public int UserId { get; set; }
        [MaxLength(20)]
        public string? UserName { get; set; }
        public int PetId { get; set; }
        [MaxLength(20)]
        public string PetName { get; set; }

        [Required, MaxLength(20)]
        public string Status { get; set; } = "Pending"; // Possible values: "Pending", "Accepted", "Declined"


    }
}
