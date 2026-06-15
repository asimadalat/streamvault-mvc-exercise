namespace StreamVault.Models.ViewModels;

public sealed class CatalogueIndexViewModel
{
    public required IEnumerable<CatalogueItem> Items { get; set; }

    public int TotalItemCount { get; set; }

    public int MovieCount { get; set; }

    public int SeriesCount { get; set; }

    public int AudiobookCount { get; set; }

    public int MusicAlbumCount { get; set; }
}