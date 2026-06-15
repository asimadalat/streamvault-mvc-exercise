using StreamVault.Models.ViewModels;

namespace StreamVault.Models;

public sealed class Audiobook : CatalogueItem
{
    public string Author { get; set; } = default!;

    public string Narrator { get; set; } = default!;

    public int DurationMinutes { get; set; }


    public override string GetTypeSpecificProperties()
    {
        return $"Author: {Author}, Narrator: {Narrator} ({DurationMinutes} mins)";
    }

    public Audiobook() { }

    public Audiobook(CreateAudiobookViewModel viewModel)
    {
        Title = viewModel.Title;
        Description = viewModel.Description;
        ReleaseDate = viewModel.ReleaseDate;
        Author = viewModel.Author;
        Narrator = viewModel.Narrator;
        DurationMinutes = viewModel.DurationMinutes;
    }

    public Audiobook(EditAudiobookViewModel viewModel)
    {
        Id = viewModel.Id;
        Title = viewModel.Title;
        Description = viewModel.Description;
        ReleaseDate = viewModel.ReleaseDate;
        Author = viewModel.Author;
        Narrator = viewModel.Narrator;
        DurationMinutes = viewModel.DurationMinutes;
    }
}