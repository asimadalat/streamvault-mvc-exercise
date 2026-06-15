namespace StreamVault.Models;

public sealed class Series : CatalogueItem
{
    public int SeasonCount { get; set; }

    public int EpisodeCount { get; set; }
}