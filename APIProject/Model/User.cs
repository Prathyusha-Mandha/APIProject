using System.ComponentModel.DataAnnotations;

namespace APIProject.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required,MaxLength(20)]
        public string Username { get; set; }
        [Required, MaxLength(20)]
        public string UserEmail { get; set; }
        [Required, MaxLength(20)]
        public string Password { get; set; }
        [Required, MaxLength(10)]
        public string Role { get; set; } 
    }
}
