using APIProject.DTO;
using APIProject.Model;
using APIProject.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIProject.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetDetailsController : ControllerBase
    {
        private readonly PetDetailsService _service;

        public PetDetailsController(PetDetailsService service)
        {
            _service = service;
        }

         [HttpGet]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetAll()
         {
            var pets = await _service.GetAllPetsAsync();

            var result = pets.Select(p => new
            {
                p.PetId,
                p.PetName,
                p.Type,
                p.Breed,
                p.Age,
                p.Status,
                p.CenterId,
                p.CenterName,
                p.AdoptionRequests
            }).ToList();

            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetById(int id)
        {
            var pet = await _service.GetPetByIdAsync(id);
            if (pet == null) return NotFound("No record found with this ID.");

            var result = new
            {
                pet.PetId,
                pet.PetName,
                pet.Type,
                pet.Breed,
                pet.Age,
                pet.Status,
                pet.CenterId,
                pet.CenterName,
                pet.AdoptionRequests
            };

            return Ok(result);
        }

        [HttpGet("name/{name}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetByName(string name)
        {
            var pet = await _service.GetPetByNameAsync(name);
            if (pet == null) return NotFound("No record found with this Name.");

            var result = new
            {
                pet.PetId,
                pet.PetName,
                pet.Type,
                pet.Breed,
                pet.Age,
                pet.Status,
                pet.CenterId,
                pet.CenterName,
                pet.AdoptionRequests
            };
            return Ok(result);
        }

        [HttpGet("breed/{breed}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetByBreed(string breed)
        {
            var pet = await _service.GetPetByBreedAsync(breed);
            if (pet == null) return NotFound("No record found with this Breed.");

            var result = new
            {
                pet.PetId,
                pet.PetName,
                pet.Type,
                pet.Breed,
                pet.Age,
                pet.Status,
                pet.CenterId,
                pet.CenterName,
                pet.AdoptionRequests
            };

            return Ok(pet);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add([FromBody] PetDetailsDTO dto)
        {
            var pet = new PetDetails
            {
                PetName = dto.PetName,
                Type = dto.Type,
                Breed = dto.Breed,
                Age = dto.Age,
                CenterId = dto.CenterId,
                CenterName = dto.CenterName,
                Status =  dto.Status
            };

            await _service.AddPetAsync(pet);
            return Ok(pet);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateById(int id, [FromBody] PetDetailsDTO dto)
        {
            var pet = new PetDetails
            {
                PetName = dto.PetName,
                Type = dto.Type,
                Breed = dto.Breed,
                Age = dto.Age,
                CenterId = dto.CenterId,
                CenterName = dto.CenterName,
                Status = dto.Status
            };

            var updated = await _service.UpdateByIdAsync(id, pet);
            if (!updated) return NotFound("No record found with this ID.");

            return Ok("Updated Succesfully");
        }

        [HttpPut("name/{name}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateByName(string name, [FromBody] PetDetailsDTO dto)
        {
            var pet = new PetDetails
            {
                PetName = dto.PetName,
                Type = dto.Type,
                Breed = dto.Breed,
                Age = dto.Age,
                CenterId = dto.CenterId,
                CenterName = dto.CenterName,
                Status = dto.Status
            };

            var updated = await _service.UpdateByNameAsync(name, pet);
            if (!updated) return NotFound("No record found with this Name.");

            return Ok("Updated Successfully");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var deleted = await _service.DeleteByIdAsync(id);
            if (!deleted) return NotFound("No record found with this ID.");

            return Ok("Deleted Successfully");
        }

        [HttpDelete("name/{name}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteByName(string name)
        {
            var deleted = await _service.DeleteByNameAsync(name);
            if (!deleted) return NotFound("No record found with this Name.");

            return Ok("Deleted Successfully");
        }
    }
}


