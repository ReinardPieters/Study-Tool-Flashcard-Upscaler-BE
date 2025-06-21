using Microsoft.AspNetCore.Mvc;
using StudyToolFlashcardUpscaler.Models.Dtos;
using StudyToolFlashcardUpscaler.Api.Services;
using System.Collections.Generic;

namespace StudyToolFlashcardUpscaler.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly UserService _userService;

        public LoginController(UserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Retrieves all users from the system.
        /// </summary>
        /// <returns>List of UserDto objects.</returns>
        [HttpGet]
        public ActionResult<List<UserDto>> GetAllUsers()
        {
            try
            {

                var users = _userService.GetAllUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPost("login")]
        public ActionResult<UserDto> Login([FromBody] LoginDto loginDto)
        {
            var user = AuthenticateUser(loginDto.username, loginDto.password);

            if (user == null)
                return Unauthorized("Invalid credentials");

            return Ok(user);
        }

        [HttpPost("create-user")]
        public ActionResult<UserDto> CreateUser([FromBody] UserDto userDto)
        {
            if (userDto == null)
            {
                return BadRequest("User data is required.");
            }

            var createdUser = _userService.CreateUser(userDto);
            return CreatedAtAction(nameof(GetAllUsers), new { id = createdUser.Id }, createdUser);
        }
        public UserDto AuthenticateUser(string username, string password)
        {
            var allUsersResults = _userService.GetAllUsers();
            var allUsers = allUsersResults;// or _users, whichever is consistent
            return allUsers.FirstOrDefault(u => u.username == username && u.password == password);
        }

    }
}
