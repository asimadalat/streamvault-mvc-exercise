using StreamVault.Models;
using StreamVault.Models.ViewModels;

namespace StreamVault.Services.Interfaces;

public interface ICatalogueService
{
    Task<CatalogueIndexViewModel> GetCatalogueItemsAsync(
        string? searchTerm,
        string? contentType);

    Task<CatalogueItem?> GetByIdAsync(Guid id);

    Task CreateAsync(CatalogueItem item);

    Task UpdateAsync(CatalogueItem item);

    Task DeleteAsync(Guid id);
}