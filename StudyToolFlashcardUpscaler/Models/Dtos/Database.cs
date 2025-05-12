namespace StudyToolFlashcardUpscaler.Models.Dtos;

public class Database
{
    public List<UserDto>? users { get; set; }
    public List<NoteDto>? notes { get; set; }
    public List<FlashCardDto>? flashCards { get; set; }
}