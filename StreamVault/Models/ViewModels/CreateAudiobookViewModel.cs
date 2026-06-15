using System.ComponentModel.DataAnnotations;

namespace StreamVault.Models.ViewModels;

public class CreateAudiobookViewModel : CreateCatalogueItemViewModel
{
    [Required(ErrorMessage = "Author is mandatory")]
    [StringLength(100)]
    public string Author { get; set; } = string.Empty;

    [Required(ErrorMessage = "Narrator is mandatory")]
    [StringLength(100)]
    public string Narrator { get; set; } = string.Empty;

    [Required(ErrorMessage = "Duration is mandatory")]
    [Range(1, 6000, ErrorMessage = "Duration must be postive and 6,000 minutes maximum")]
    public int DurationMinutes { get; set; }
}

