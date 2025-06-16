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

    }
}
