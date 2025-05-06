using Microsoft.AspNetCore.Mvc;
using StudyToolFlashcardUpscaler.Models.Dtos;

namespace StudyToolFlashcardUpscaler.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoteController : ControllerBase
    {
        private static readonly List<NoteDto> Notes = new();

        // GET: api/note
        [HttpGet]
        public ActionResult<List<NoteDto>> GetNotes()
        {
            return Ok(Notes);
        }

        [HttpPost]
        public ActionResult<NoteDto> AddNote([FromBody] NoteDto newNote)
        {
            Notes.Add(newNote);
            return CreatedAtAction(nameof(GetNotes), new { id = newNote.Code }, newNote);
        }

        [HttpPut("{noteCode}")]
        public IActionResult EditNote(Guid noteCode, [FromBody] NoteDto updatedNote)
        {
            var existing = Notes.FirstOrDefault(n => n.Code == noteCode);
            if (existing == null) return NotFound();

            existing.Topic = updatedNote.Topic;
            existing.Description = updatedNote.Description;
            existing.Notes = updatedNote.Notes;

            return NoContent();
        }

        [HttpDelete("{noteCode}")]
        public IActionResult DeleteNote(Guid noteCode)
        {
            var note = Notes.FirstOrDefault(n => n.Code == noteCode);
            if (note == null) return NotFound();

            Notes.Remove(note);
            return NoContent();
        }
    }
}
