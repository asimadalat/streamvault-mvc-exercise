namespace StreamVault.Models.ViewModels;

public sealed class EditMusicAlbumViewModel : CreateMusicAlbumViewModel
{
    public Guid Id { get; set; }

    public EditMusicAlbumViewModel() { }

    public EditMusicAlbumViewModel(MusicAlbum musicAlbum)
    {
        Id = musicAlbum.Id;
        Title = musicAlbum.Title;
        Description = musicAlbum.Description;
        ReleaseDate = musicAlbum.ReleaseDate;
        Artist = musicAlbum.Artist;
        RecordLabel = musicAlbum.RecordLabel;
        TrackCount = musicAlbum.TrackCount;
    }
}