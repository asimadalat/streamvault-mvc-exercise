namespace StreamVault.Models.ViewModels;

public sealed class EditSeriesViewModel : CreateSeriesViewModel
{
    public Guid Id { get; set; }

    public EditSeriesViewModel() { }

    public EditSeriesViewModel(Series series)
    {
        Id = series.Id;
        Title = series.Title;
        Description = series.Description;
        ReleaseDate = series.ReleaseDate;
        SeasonCount = series.SeasonCount;
        EpisodeCount = series.EpisodeCount;
    }
}