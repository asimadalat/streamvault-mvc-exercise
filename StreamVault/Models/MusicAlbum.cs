namespace StreamVault.Models;

public sealed class MusicAlbum : CatalogueItem
{
    public string Artist { get; set; } = default!;

    public string RecordLabel { get; set; } = default!;

    public int TrackCount { get; set; }
}