using APIProject.Model;
using APIProject.Repository;
using System.ComponentModel.DataAnnotations;

namespace APIProject.DTO
{
    public class AdoptionCenterDTO
    {
        public string CenterName { get; set; }
        public string Location { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
       
    }

}
