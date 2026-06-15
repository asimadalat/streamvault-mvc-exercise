using StreamVault.Models;

namespace StreamVault.Services.Interfaces;

public interface ICatalogueService
{
    Task<IEnumerable<CatalogueItem>> GetCatalogueItemsAsync(
        string? searchTerm,
        string? contentType);

    Task<CatalogueItem?> GetByIdAsync(Guid id);

    Task CreateAsync(CatalogueItem item);

    Task UpdateAsync(CatalogueItem item);

    Task DeleteAsync(Guid id);
}