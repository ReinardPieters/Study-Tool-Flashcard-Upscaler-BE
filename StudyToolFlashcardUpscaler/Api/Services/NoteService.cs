using StudyToolFlashcardUpscaler.Api.Services;
using StudyToolFlashcardUpscaler.Models.Dtos;

namespace StudyToolFlashcardUpscaler.Services
{
    public class NoteService
    {
        private readonly DatabaseService _database;
        readonly Random rnd = new Random();
        public NoteService(DatabaseService database)
        {
            _database = database;
            
        }

        public IEnumerable<NoteDto> GetAllNotes()
        {
            return _database.GetNotes();
        }

        public NoteDto? GetNote(int id)
        {
            if (_database.Data == null)
                return null;

            var note = _database.Data.notes!.FirstOrDefault(x => x.code == id);
            if (note != null)
            {
                return note;
            }
            else
            {
                return null;
            }
        }

        public NoteDto? AddNote(NoteDto newNote)
        {
            newNote.code = rnd.Next(1,1000);
            if (_database.Data!.notes == null)
                _database.Data.notes = new List<NoteDto>();

            _database.Data.notes.Add(newNote);
            _database.SaveData();
            return newNote;
        }

        public bool EditNote(int noteCode, NoteDto updatedNote)
        {
            var note = _database.Data?.notes?.FirstOrDefault(n => n.code == noteCode);
            if (note == null)
                return false;

            note.topic = updatedNote.topic;
            note.description = updatedNote.description;
            note.keyPoints = updatedNote.keyPoints;
            _database.SaveData();
            return true;
        }

        //TODO: add delete later
        // public string DeleteNote(int noteCode)
        // {
        //     var note = _database.Data?.notes?.FirstOrDefault(n => n.code == noteCode);
        //     if (note == null)
        //         return false;

        //     _database.Data.notes.Remove(note);
        //     _database.SaveData();
        //     return "✅ Note deleted successfully :)";
        // }
    }
}
