namespace StreamVault.Models;

public abstract class CatalogueItem
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Title { get; set; } = default!;

    public string? Description { get; set; }

    public DateTime ReleaseDate { get; set; }
}