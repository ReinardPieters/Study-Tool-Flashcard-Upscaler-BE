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
    public List<LoginDto> Login()
    {
        
        // if (request.Username == "admin" && request.Password == "password123"){
        //     return Ok(true);
        // }
        // else
        // {
        //     return Ok(false);
        // }

        return LoadUsersFromJson();
    }

     private List<LoginDto> LoadUsersFromJson()
    {
        var filePath = Path.Combine("SeriousDB/SeriosDB.json");
        try
        {
            var json = System.IO.File.ReadAllText(filePath);
            var db = JsonSerializer.Deserialize<List<LoginDto>>(json);
            return db;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Deserialization failed: {ex.Message}");
            throw;
        }
    }
}