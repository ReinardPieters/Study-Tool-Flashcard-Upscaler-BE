using Microsoft.AspNetCore.Mvc;
using StudyToolFlashcardUpscaler.Models.Dtos;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    [HttpPost]
    public ActionResult<bool> Login([FromBody] LoginDto request)
    {
        
        // if (request.Username == "admin" && request.Password == "password123"){
        //     return Ok(true);
        // }
        // else
        // {
        //     return Ok(false);
        // }

        return Ok(true);
    }
}
