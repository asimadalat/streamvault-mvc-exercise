namespace StreamVault.Models;

public sealed class Audiobook : CatalogueItem
{
    public string Author { get; set; } = default!;

    public string Narrator { get; set; } = default!;

    public int DurationMinutes { get; set; }
}