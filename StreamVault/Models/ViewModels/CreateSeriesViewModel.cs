using System.ComponentModel.DataAnnotations;

namespace StreamVault.Models.ViewModels;

public class CreateSeriesViewModel : CreateCatalogueItemViewModel
{
    [Required]
    [Range(1, 300, ErrorMessage = "Number of seasons must be positive and below 300")]
    public int SeasonCount { get; set; }

    [Required]
    [Range(1, 10000, ErrorMessage = "Number of episodes must be postive and below 10,000")]
    public int EpisodeCount { get; set; }
}