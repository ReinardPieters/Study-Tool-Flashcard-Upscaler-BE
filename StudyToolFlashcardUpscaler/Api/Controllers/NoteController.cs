using Microsoft.AspNetCore.Mvc;
using StudyToolFlashcardUpscaler.Models.Dtos;
using StudyToolFlashcardUpscaler.Services;

namespace StudyToolFlashcardUpscaler.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoteController(NoteService noteService) : ControllerBase
    {
        private readonly NoteService _noteService = noteService;

        [HttpGet]
        public ActionResult<List<NoteDto>> GetAllNotes()
        {
            return Ok(_noteService.GetAllNotes());
        }

        [HttpPost]
        public ActionResult<NoteDto> AddNote([FromBody] NoteDto newNote)
        {
            var added = _noteService.AddNote(newNote);
            return CreatedAtAction(nameof(GetAllNotes), new { id = added.code }, added);
        }

        [HttpPut("{noteCode}")]
        public ActionResult EditNote(int noteCode, [FromBody] NoteDto updatedNote)
        {
            bool result = _noteService.EditNote(noteCode, updatedNote);
            return result ? NoContent() : NotFound(result);
        }

        // [HttpDelete("{noteCode}")]
        // public IActionResult DeleteNote(int noteCode)
        // {
        //     var result = _noteService.DeleteNote(noteCode);
        //     return result ? NoContent() : NotFound("Note was not found");
        // }
    }
}