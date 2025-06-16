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

        /// <summary>
        /// Returns a list of all notes
        /// </summary>
        [HttpGet]
        public ActionResult<List<NoteDto>> GetAllNotes()
        {
            return Ok(_noteService.GetAllNotes());
        }

        /// <summary>
        /// Returns a sigle note by its ID
        /// </summary>
        [HttpGet("by-id")]
        public ActionResult<NoteDto> GetNote(int id)
        {
            return Ok(_noteService.GetNote(id));
        }

         /// <summary>
        /// Returns the newly added note
        /// </summary>
        [HttpPost]
        public ActionResult<NoteDto> AddNote([FromBody] NoteDto newNote)
        {
            var added = _noteService.AddNote(newNote);
            return CreatedAtAction(nameof(GetAllNotes), new { id = added!.Id }, added);
        }

        /// <summary>
        /// Returns the updated note
        /// </summary>
        [HttpPut("{noteCode}")]
        public ActionResult EditNote(int noteCode, [FromBody] NoteDto updatedNote)
        {
            bool result = _noteService.EditNote(noteCode, updatedNote);
            return result ? NoContent() : NotFound(result);
        }

        [HttpDelete("{noteCode}")]
        public string DeleteNote(int id)
        {
            var result = _noteService.DeleteNote(id);
            return result;
        }
    }
}