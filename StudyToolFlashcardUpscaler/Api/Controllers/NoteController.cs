using System.Net;
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
        [HttpPut("{id}")]
        public ActionResult EditNote(int id, [FromBody] NoteDto updatedNote)
        {
            bool result = _noteService.EditNote(id, updatedNote);
            return result ? NoContent() : NotFound(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNote(int id)
        {
            var result = _noteService.DeleteNote(id);
            if (result)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}