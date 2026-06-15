using StreamVault.Models.ViewModels;

namespace StreamVault.Models;

public sealed class MusicAlbum : CatalogueItem
{
    public string Artist { get; set; } = default!;

    public string RecordLabel { get; set; } = default!;

    public int TrackCount { get; set; }


    public override string DisplayType => "Music Album";

    public override string GetTypeSpecificProperties()
    {
        return $"Artist: {Artist}, Label: {RecordLabel} ({TrackCount} tracks)";
    }

    public MusicAlbum() { }

    public MusicAlbum(CreateMusicAlbumViewModel viewModel)
    {
        Title = viewModel.Title;
        Description = viewModel.Description;
        ReleaseDate = viewModel.ReleaseDate;
        Artist = viewModel.Artist;
        RecordLabel = viewModel.RecordLabel;
        TrackCount = viewModel.TrackCount;
    }

    public MusicAlbum(EditMusicAlbumViewModel viewModel)
    {
        Id = viewModel.Id;
        Title = viewModel.Title;
        Description = viewModel.Description;
        ReleaseDate = viewModel.ReleaseDate;
        Artist = viewModel.Artist;
        RecordLabel = viewModel.RecordLabel;
        TrackCount = viewModel.TrackCount;
    }
}