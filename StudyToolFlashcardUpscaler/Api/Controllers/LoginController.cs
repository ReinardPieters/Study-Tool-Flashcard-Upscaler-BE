using Microsoft.AspNetCore.Mvc;
using StudyToolFlashcardUpscaler.Models.Dtos;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    [HttpGet]
    public List<User> Login()
    {
        // Todo : Fix what ever the fuck this is
        // if (request.Username == "admin" && request.Password == "password123"){
        //     return Ok(true);
        // }
        // else
        // {
        //     return Ok(false);
        // }

        return LoadUsersFromJson();
    }

    private List<User> LoadUsersFromJson()
    {
        var filePath = Path.Combine("SeriousDB/SeriosDB.json");

        var json = System.IO.File.ReadAllText(filePath);
        var db = JsonSerializer.Deserialize<Database>(json);
        return db.user;
    }
}
