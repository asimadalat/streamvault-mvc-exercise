using StreamVault.Models.ViewModels;

namespace StreamVault.Models;

public sealed class Series : CatalogueItem
{
    public int SeasonCount { get; set; }

    public int EpisodeCount { get; set; }


    public override string GetTypeSpecificProperties()
    {
        return $"{SeasonCount} seasons ({EpisodeCount} episodes)";
    }

    public Series() { }

    public Series(CreateSeriesViewModel viewModel)
    {
        Title = viewModel.Title;
        Description = viewModel.Description;
        ReleaseDate = viewModel.ReleaseDate;
        SeasonCount = viewModel.SeasonCount;
        EpisodeCount = viewModel.EpisodeCount;
    }

    public Series(EditSeriesViewModel viewModel)
    {
        Id = viewModel.Id;
        Title = viewModel.Title;
        Description = viewModel.Description;
        ReleaseDate = viewModel.ReleaseDate;
        SeasonCount = viewModel.SeasonCount;
        EpisodeCount = viewModel.EpisodeCount;
    }
}