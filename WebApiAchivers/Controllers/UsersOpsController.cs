using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using MyData.Interface;
using MyData.Models;
using WebApiAchivers.Services;

namespace WebApiAchivers.Controllers
{
    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }


    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersOpsController : ControllerBase
    {
        public readonly IUsers _service;

        private readonly JwtService _jwtService;
        public UsersOpsController(IUsers userbl, JwtService jwtService)
        {
            _service = userbl;
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            // Demo validation (replace with DB check)
            if (request.Username == "admin" && request.Password == "1234")
            {
                var token = _jwtService.GenerateToken(request.Username);
                return Ok(new { token });
            }
            return Unauthorized();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> UsersData()
        {
            var res = await _service.GetAllUsers();//users
            return Ok(res); //json // 200  , success 
        }

        // CREATE
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] Users data)
        {
            if (data == null)
                return BadRequest("Invalid user data"); // 404

            await _service.AddUsers(data);
            return Ok("User added successfully");
        }

        // READ (BY ID)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _service.GetUserByID(id);

            if (user == null)
                return NotFound("User not found");// 404

            return Ok(user);
        }

        // UPDATE
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] Users data)
        {
            if (id != data.ID)
                return BadRequest("ID mismatch");

            var existingUser = await _service.GetUserByID(id);
            if (existingUser == null)
                return NotFound("User not found");

            await _service.EditUsers(data);
            return Ok("User updated successfully");
        }

        // DELETE
        [HttpDelete("{id}")]
      
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _service.GetUserByID(id);

            if (user == null)
                return NotFound("User not found");

            await _service.DeleteUser(id);
            return Ok("User deleted successfully");
        }
    }
}
