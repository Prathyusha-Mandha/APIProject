using APIProject.DTO;
using APIProject.Model;
using APIProject.Service;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PetAdoption.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdoptionRequestsController : ControllerBase
    {
        private readonly AdoptionRequestService _service;

        public AdoptionRequestsController(AdoptionRequestService service)
        {
            _service = service;

        }

        
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllRequestsAsync());
        }

        
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetById(int id)
        {
            var request = await _service.GetByIdAsync(id);
            if (request == null) return NotFound("Record not found with this Request Id.");
            return Ok(request);


        }

        
        [HttpGet("user/{username}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetByUser(string username)
        {
            var requests = await _service.GetByUserNameAsync(username);
            if (requests == null) return NotFound("Record not found with this Username.");

            return Ok(requests);
        }

        
        [HttpGet("userId/{userId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            var requests = await _service.GetByUserIdAsync(userId);

            if (requests == null) return NotFound("Record not found with this UserId.");
            return Ok(requests);
        }

        
        [HttpGet("petId/{petId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetByPetId(int petId)
        {
            var requests = await _service.GetByPetIdAsync(petId);

            if (requests == null) return NotFound("Record not found with this PetId.");
            return Ok(requests);
        }

        [HttpGet("pet/{petName}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetByPetName(string petName)
        {
            var requests = await _service.GetByPetNameAsync(petName);
            if (requests == null) return NotFound("Record not found with this Petname.");
            return Ok(requests);
        }

        [HttpPut("requestid/{requestId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateByRequestId(int requestId, [FromBody] AdoptionRequestDTO dto)
        {
            var success = await _service.UpdateByRequestIdAsync(requestId, new AdoptionRequest { Status = dto.Status });
            if (!success)
                return NotFound($"No adoption request found with RequestId = {requestId}");

            return Ok("Status updated successfully.");
        }

        
        [HttpPut("userid/{userId}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> UpdateByUserId(int userId, [FromBody] AdoptionRequestDTO dto)
        {
            var success = await _service.UpdateByUserIdAsync(userId, new AdoptionRequest { Status = dto.Status });
            if (!success)
                return NotFound($"No adoption requests found for UserId = {userId}");

            return Ok("Status updated successfully.");
        }

        
        [HttpPut("username/{userName}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> UpdateByUserName(string userName, [FromBody] AdoptionRequestDTO dto)
        {
            var success = await _service.UpdateByUserNameAsync(userName, new AdoptionRequest { Status = dto.Status });
            if (!success)
                return NotFound($"No adoption requests found for UserName = {userName}");

            return Ok("Status updated successfully.");
        }

        [HttpPut("petid/{petId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateByPetId(int petId, [FromBody] AdoptionRequestDTO dto)
        {
            var success = await _service.UpdateByPetIdAsync(petId, new AdoptionRequest { Status = dto.Status });
            if (!success)
                return NotFound($"No adoption requests found for PetId = {petId}");

            return Ok("Status updated successfully.");
        }

        [HttpPut("petname/{petName}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateByPetName(string petName, [FromBody] AdoptionRequestDTO dto)
        {
            var success = await _service.UpdateByPetNameAsync(petName, new AdoptionRequest { Status = dto.Status });
            if (!success)
                return NotFound($"No adoption requests found for PetName = {petName}");

            return Ok("Status updated successfully.");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteByRequestId(int id)
        {
            var success = await _service.DeleteByRequestIdAsync(id);
            if (!success)
                return NotFound("No record found with this Request Id.");
            return Ok("Record deleted successfully.");
        }
        [HttpDelete("userid/{userId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteByUserId(int userId)
        {
            var success = await _service.DeleteByUserIdAsync(userId);
            if (!success)
                return NotFound("No record found with this User Id.");
            return Ok("Record deleted successfully.");
        }
        [HttpDelete("username/{userName}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteByUserName(string userName)
        {
            var success = await _service.DeleteByUserNameAsync(userName);
            if (!success)
                return NotFound("No record found with this User Name.");
            return Ok("Record deleted successfully.");
        }
        [HttpDelete("petid/{petId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteByPetId(int petId)
        {
            var success = await _service.DeleteByPetIdAsync(petId);
            if (!success)
                return NotFound("No record found with this Pet Id.");
            return Ok("Record deleted successfully.");
        }
        [HttpDelete("petname/{petName}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteByPetName(string petName)
        {
            var success = await _service.DeleteByPetNameAsync(petName);
            if (!success)
                return NotFound("No record found with this Pet Name.");
            return Ok("Record deleted successfully.");
        }
        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Create([FromBody] AdoptionRequest request)
        {
            await _service.AddAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = request.RequestId }, request);
        }


    }
}
