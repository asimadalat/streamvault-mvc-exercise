namespace StreamVault.Models.ViewModels;

public sealed class EditMovieViewModel : CreateMovieViewModel
{
    public Guid Id { get; set; }

    public EditMovieViewModel() { }

    public EditMovieViewModel(Movie movie)
    {
        Id = movie.Id;
        Title = movie.Title;
        Description = movie.Description;
        ReleaseDate = movie.ReleaseDate;
        Director = movie.Director;
        DurationMinutes = movie.DurationMinutes;
    }
}