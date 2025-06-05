namespace StudyToolFlashcardUpscaler.Models.Dtos
{
    public class FlashCardDto
    {
        public int Id { get; set; }
        public string? Question { get; set; }
        public string? Answer { get; set; }
        public Dictionary<string, string>? Options { get; set; }
    }
}