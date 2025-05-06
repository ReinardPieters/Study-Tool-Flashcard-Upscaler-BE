namespace StudyToolFlashcardUpscaler.Models.Dtos
{
    public class NoteDto
    {
        public Guid Code { get; set; } = Guid.NewGuid();  
        public required string Topic { get; set; } 
        public required string Description { get; set; }
        public List<string>? Notes { get; set; } 
    }
}
