namespace StreamVault.Models.ViewModels;

public sealed class EditAudiobookViewModel : CreateAudiobookViewModel
{
    public Guid Id { get; set; }

    public EditAudiobookViewModel() { }

    public EditAudiobookViewModel(Audiobook audiobook)
    {
        Id = audiobook.Id;
        Title = audiobook.Title;
        Description = audiobook.Description;
        ReleaseDate = audiobook.ReleaseDate;
        Author = audiobook.Author;
        Narrator = audiobook.Narrator;
        DurationMinutes = audiobook.DurationMinutes;
    }
}