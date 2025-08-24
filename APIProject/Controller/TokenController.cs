using APIProject.Data;
using APIProject.DTO;
using APIProject.Interface;
using APIProject.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIProject.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly PetContext _con;
        private readonly ITokenGenerate _tokenService;

        public TokenController(PetContext con, ITokenGenerate tokenService)
        {
            _con = con;
            _tokenService = tokenService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserDTO userData)
        {
            if (userData == null || string.IsNullOrEmpty(userData.Username) || string.IsNullOrEmpty(userData.Password)
                || string.IsNullOrEmpty(userData.Role))
            {
                return BadRequest("Invalid request data");
            }

            var user = await GetUser(userData.Username, userData.Password, userData.Role);

            if (user == null)
            {

                return Unauthorized("Incorrect Details");
            }

            var token = _tokenService.GenerateToken(user);
            return Ok(new { token });
        }

        private async Task<User?> GetUser(string name, string password, string role)
        {
            return await _con.Users
                .FirstOrDefaultAsync(u => u.Username == name && u.Password == password && u.Role == role);
        }
    }
}
