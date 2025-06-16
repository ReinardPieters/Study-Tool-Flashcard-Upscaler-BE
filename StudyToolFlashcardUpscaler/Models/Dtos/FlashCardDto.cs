namespace StudyToolFlashcardUpscaler.Models.Dtos
{
    public class FlashCardDto
    {
        public int Id { get; set; }
        public required string Question { get; set; }
        public required string Answer { get; set; }
        public required string[] Options { get; set; }
    }
}