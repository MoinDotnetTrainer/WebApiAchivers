using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyData.Interface;
using MyData.Models;

namespace WebApiAchivers.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersOpsController : ControllerBase
    {
        public readonly IUsers _service;
        public UsersOpsController(IUsers userbl)
        {
            _service = userbl;
        }

        [HttpGet]
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
