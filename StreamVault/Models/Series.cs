namespace StreamVault.Models;

public sealed class Series : CatalogueItem
{
    public int SeasonCount { get; set; }

    public int EpisodeCount { get; set; }


    public override string GetTypeSpecificProperties()
    {
        return $"{SeasonCount} seasons ({EpisodeCount} episodes)";
    }
}