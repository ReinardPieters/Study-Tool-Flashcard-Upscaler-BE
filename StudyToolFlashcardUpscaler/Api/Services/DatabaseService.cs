using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using StudyToolFlashcardUpscaler.Models.Dtos;

namespace StudyToolFlashcardUpscaler.Api.Services
{
    public class DatabaseService
    {
        private static readonly string DatabaseFilePath = Path.Combine(AppContext.BaseDirectory, "SeriousDB/SeriousDB.json");
        public Database? Data { get; private set; }

        public void LoadData()
        {
            if (!File.Exists(DatabaseFilePath))
            {
                Console.WriteLine("❌ JSON file not found at: " + DatabaseFilePath);
                return;
            }

            try
            {
                string json = File.ReadAllText(DatabaseFilePath);
                Data = JsonSerializer.Deserialize<Database>(json);
                Console.WriteLine("✅ Database loaded successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ Error reading or parsing JSON: {ex.Message}");
            }
        }

        // Convenience accessors
        public IEnumerable<NoteDto> GetNotes() => Data?.notes ?? Enumerable.Empty<NoteDto>();
        public IEnumerable<FlashCardDto> GetCards() => Data?.cards ?? Enumerable.Empty<FlashCardDto>();
        public IEnumerable<UserDto> GetUsers() => Data?.users ?? Enumerable.Empty<UserDto>();
    }
}
