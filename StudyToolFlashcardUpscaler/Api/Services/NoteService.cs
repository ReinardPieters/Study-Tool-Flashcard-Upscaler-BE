// Services/NoteService.cs
using StudyToolFlashcardUpscaler.Models.Dtos;

namespace StudyToolFlashcardUpscaler.Services
{
    public class NoteService
    {
        private static readonly List<NoteDto> Notes = [];

        public List<NoteDto> GetAllNotes()
        {
            return Notes;
        }

        public NoteDto AddNote(NoteDto newNote)
        {
            Notes.Add(newNote);
            return newNote;
        }

        public bool EditNote(Guid noteCode, NoteDto updatedNote)
        {
            var existing = Notes.FirstOrDefault(n => n.Code == noteCode);
            if (existing == null) return false;

            existing.Topic = updatedNote.Topic;
            existing.Description = updatedNote.Description;
            existing.Notes = updatedNote.Notes;
            return true;
        }

        public bool DeleteNote(Guid noteCode)
        {
            var note = Notes.FirstOrDefault(n => n.Code == noteCode);
            if (note == null) return false;

            Notes.Remove(note);
            return true;
        }
    }
}
