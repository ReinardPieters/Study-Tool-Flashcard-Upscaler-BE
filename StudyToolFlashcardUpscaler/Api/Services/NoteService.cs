using StudyToolFlashcardUpscaler.Api.Services;
using StudyToolFlashcardUpscaler.Models.Dtos;

namespace StudyToolFlashcardUpscaler.Services
{
    public class NoteService
    {
        private readonly DatabaseService _database;
        public NoteService(DatabaseService database)
        {
            _database = database;
            _database.LoadData();
        }

        public IEnumerable<NoteDto> GetAllNotes()
        {
            return _database.GetNotes();
        }

        public NoteDto? GetNote(int id)
        {
            if (_database.Data == null)
                return null;

            var note = _database.Data.notes!.FirstOrDefault(x => x.Id == id);
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
            if (_database.Data!.notes == null)
                _database.Data.notes = new List<NoteDto>();

            int newId = 0;

            if (_database.Data.notes.Count > 0)
            {
                var existingIds = _database.Data.notes.Select(n => n.Id);
                newId = existingIds.Max() + 1;
            }

            newNote.Id = newId;
            _database.Data.notes.Add(newNote);
            _database.SaveData();

            return newNote;
        }

        public bool EditNote(int id, NoteDto updatedNote)
        {
            var note = _database.Data?.notes?.FirstOrDefault(n => n.Id == id);
            if (note == null)
                return false;

            note.topic = updatedNote.topic;
            note.description = updatedNote.description;
            note.points = updatedNote.points;
            _database.SaveData();
            return true;
        }

        public string DeleteNote(int id)
        {
            var note = _database.Data?.notes?.FirstOrDefault(n => n.Id == id);
            if (note == null)
                return "Could not find note.";

            _database.Data.notes.Remove(note);
            _database.SaveData();
            return "✅ Note deleted successfully :)";
        }
    }
}
