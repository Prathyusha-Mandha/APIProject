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
    public class AdoptionCentersController : ControllerBase
    {
        private readonly AdoptionCenterService _service;

        public AdoptionCentersController(AdoptionCenterService service)
        {
            _service = service;
        }

        // GET: api/AdoptionCenters
        [HttpGet]
        [Authorize (Roles = "Admin,User")]
        public async Task<IActionResult> GetAll()
        {
            var centers = await _service.GetAllCentersAsync();

            var result = centers.Select(c => new
            {
                c.CenterId,
                c.CenterName,
                c.Location,
                c.ContactNumber,
                c.Email,
                Pets = c.Pets.Select(p => new
                {
                    p.PetId,
                    p.PetName,
                    p.Type,
                    p.Breed,
                    p.Age,
                    p.Status,
                    p.CenterId,
                    p.CenterName
                }).ToList()
            }).ToList();

            return Ok(result);
        }

        // GET: api/AdoptionCenters/{id}
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetById(int id)
        {
            var center = await _service.GetCenterByIdAsync(id);
            if (center == null) return NotFound("No record found with this ID.");

            var result = new
            {
                center.CenterId,
                center.CenterName,
                center.Location,
                center.ContactNumber,
                center.Email,
                Pets = center.Pets.Select(p => new
                {
                    p.PetId,
                    p.PetName,
                    p.Type,
                    p.Breed,
                    p.Age,
                    p.Status,
                    p.CenterId,
                    p.CenterName
                }).ToList()
            };

            return Ok(result);
        }

        // GET: api/AdoptionCenters/name/{name}
        [HttpGet("name/{name}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetByName(string name)
        {
            var center = await _service.GetCenterByNameAsync(name);
            if (center == null) return NotFound("No record found with this Name.");

            var result = new
            {
                center.CenterId,
                center.CenterName,
                center.Location,
                center.ContactNumber,
                center.Email,
                Pets = center.Pets.Select(p => new
                {
                    p.PetId,
                    p.PetName,
                    p.Type,
                    p.Breed,
                    p.Age,
                    p.Status,
                    p.CenterId,
                    p.CenterName
                }).ToList()
            };

            return Ok(result);
        }

        // POST: api/AdoptionCenters
        [HttpPost]
        [Authorize (Roles = "Admin")]
        public async Task<IActionResult> Add([FromBody] AdoptionCenterDTO dto)
        {
            var center = new AdoptionCenter
            {
                CenterName = dto.CenterName,
                Location = dto.Location,
                ContactNumber = dto.ContactNumber,
                Email = dto.Email
            };

            await _service.AddCenterAsync(center);
            return Ok(dto);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Update(int id, [FromBody] AdoptionCenterDTO dto)
        {
            var center = new AdoptionCenter
            {
                CenterName = dto.CenterName,
                Location = dto.Location,
                ContactNumber = dto.ContactNumber,
                Email = dto.Email
            };

            var updated = await _service.UpdateCenterByIdAsync(id, center);
            if (!updated) return NotFound("No record found with this ID.");

            return NoContent();
        }

        [HttpPut("name/{name}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateByName(string name, [FromBody] AdoptionCenterDTO dto)
        {
            var center = new AdoptionCenter
            {
                CenterName = dto.CenterName,
                Location = dto.Location,
                ContactNumber = dto.ContactNumber,
                Email = dto.Email
            };

            var updated = await _service.UpdateCenterByNameAsync(name, center);
            if (!updated) return NotFound("No record found with this name.");

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteCenterByIdAsync(id);
            if (!deleted) return NotFound("No record found with this ID.");

            return NoContent();
        }

        [HttpDelete("name/{name}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteByName(string name)
        {
            var deleted = await _service.DeleteCenterByNameAsync(name);
            if (!deleted) return NotFound("No record found with this name.");

            return NoContent();
        }
    }
}
