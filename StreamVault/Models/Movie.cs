namespace StreamVault.Models;

public sealed class Movie : CatalogueItem
{
    public int DurationMinutes { get; set; }

    public string Director { get; set; } = default!;
}