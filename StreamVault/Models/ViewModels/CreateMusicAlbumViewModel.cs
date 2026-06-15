using System.ComponentModel.DataAnnotations;

namespace StreamVault.Models.ViewModels;

public class CreateMusicAlbumViewModel : CreateCatalogueItemViewModel
{
    [Required(ErrorMessage = "Artist is mandatory")]
    [StringLength(100)]
    public string Artist { get; set; } = string.Empty;

    [Required(ErrorMessage = "Record label is mandatory")]
    [StringLength(100)]
    public string RecordLabel { get; set; } = string.Empty;

    [Required(ErrorMessage = "Number of tracks is mandatory")]
    [Range(1, 1000, ErrorMessage = "Number of tracks must be postive and below 1,000")]
    public int TrackCount { get; set; }
}

