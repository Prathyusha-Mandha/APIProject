using APIProject.DTO;
using APIProject.Model;
using APIProject.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace APIProject.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _service;

        public UsersController(UserService service)
        {
            _service = service;
        }

        // ----------------- CRUD -----------------

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _service.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _service.GetUserByIdAsync(id);
            if (user == null) return NotFound("Record not found with this Id.");
            return Ok(user);
        }

        [HttpGet("name/{name}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetByName(string name)
        {
            var user = await _service.GetUserByNameAsync(name);
            if (user == null) return NotFound("Record not found with this name."); ;
            return Ok(user);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> Add([FromBody] User user)
        {
            await _service.AddUserAsync(user);
            return CreatedAtAction(nameof(GetById), new { id = user.UserId }, user);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> Update(int id, [FromBody] UserDTO userDto)
        {
            
            var existingUser = await _service.GetUserByIdAsync(id);
            if (existingUser == null)
                return NotFound("No record found with this Id.");

            
            existingUser.Username = userDto.Username ?? existingUser.Username;
            existingUser.Password = userDto.Password ?? existingUser.Password;
            
            await _service.UpdateByIdAsync(id,existingUser);

            return Ok("Successfully Updated");
        }


        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var user = await _service.GetUserByIdAsync(id);
            if (user == null)
                return NotFound("No record found with this Id.");

            await _service.DeleteByIdAsync(id);
            return Ok("User deleted successfully.");
        }

        
        [HttpDelete("name/{name}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteByName(string name)
        {
            var user = await _service.GetUserByNameAsync(name);
            if (user == null)
                return NotFound("No record found with this Name.");

            await _service.DeleteUserAsync(name);
            return Ok("User deleted successfully.");
        }


        
        [HttpGet("{id}/role")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetRole(int id)
        {
            var role = await _service.GetRoleByIdAsync(id);
            if (role == null) return NotFound("Record not found with this Id.");
            return Ok(new { UserId = id, Role = role });
        }

        [HttpGet("{id}/is-admin")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> IsAdmin(int id)
        {
            var user = await _service.GetUserByIdAsync(id);
            if (user == null)
                return NotFound("No record found with this Id.");

            var isAdmin = await _service.IsAdminAsync(id);
            return Ok(new { UserId = id, IsAdmin = isAdmin });
        }

        [HttpGet("{id}/is-user")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> IsUser(int id)
        {
            var user = await _service.GetUserByIdAsync(id);
            if (user == null)
                return NotFound( "No record found with this Id.");

            var isUser = await _service.IsUserAsync(id);
            return Ok(new { UserId = id, IsUser = isUser });
        }

        

        
    }

    
}
