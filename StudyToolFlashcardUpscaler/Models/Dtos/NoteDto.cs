namespace StudyToolFlashcardUpscaler.Models.Dtos
{
    public class NoteDto
    {
        public Guid code { get; set; } = Guid.NewGuid();
        public required string topic { get; set; }
        public required string description { get; set; }
        public List<string>? keyPoints { get; set; }
    }
}
