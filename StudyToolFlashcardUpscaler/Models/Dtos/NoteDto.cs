namespace StudyToolFlashcardUpscaler.Models.Dtos
{
    public class NoteDto
    {
        public required int Id { get; set; }
        public required string topic { get; set; }
        public required string description { get; set; }
        public required string[] points { get; set; }
    }
}
