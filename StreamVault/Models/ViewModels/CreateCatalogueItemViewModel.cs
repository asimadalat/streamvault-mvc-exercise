using System.ComponentModel.DataAnnotations;

namespace StreamVault.Models.ViewModels;

public class CreateCatalogueItemViewModel
{
    [Required(ErrorMessage = "Title is mandatory")]
    [StringLength(100)]
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
}