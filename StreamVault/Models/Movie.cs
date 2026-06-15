using StreamVault.Models.ViewModels;

namespace StreamVault.Models;

public sealed class Movie : CatalogueItem
{
    public int DurationMinutes { get; set; }

    public string Director { get; set; } = default!;


    public override string GetTypeSpecificProperties()
    {
        return $"Director: {Director} ({DurationMinutes} mins)";
    }

    public Movie() { }

    public Movie(CreateMovieViewModel viewModel)
    {
        Title = viewModel.Title;
        Description = viewModel.Description;
        ReleaseDate = viewModel.ReleaseDate;
        Director = viewModel.Director;
        DurationMinutes = viewModel.DurationMinutes;
    }
}