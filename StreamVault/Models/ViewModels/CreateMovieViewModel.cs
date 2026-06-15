using System.ComponentModel.DataAnnotations;

namespace StreamVault.Models.ViewModels;

public class CreateMovieViewModel : CreateCatalogueItemViewModel
{
    [Required]
    public string Director { get; set; } = string.Empty;

    [Required]
    [Range(1, 1000, ErrorMessage = "Duration must be postive and below 1,000 mins")]
    public int DurationMinutes { get; set; }
}