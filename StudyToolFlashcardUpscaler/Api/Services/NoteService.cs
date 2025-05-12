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

        // public bool EditNote(string noteCode, NoteDto updatedNote)
        // {
        //     var existing = Notes.FirstOrDefault(n => n.code == noteCode);
        //     if (existing == null) return false;

        //     existing.topic = updatedNote.topic;
        //     existing.description = updatedNote.description;
        //     existing.keyPoints = updatedNote.keyPoints;
        //     return true;
        // }

        // public bool DeleteNote(string noteCode)
        // {
        //     var note = Notes.FirstOrDefault(n => n.code == noteCode);
        //     if (note == null) return false;

        //     Notes.Remove(note);
        //     return true;
        // }
    }
}
