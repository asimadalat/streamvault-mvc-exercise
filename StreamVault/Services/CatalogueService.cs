using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StreamVault.Data;
using StreamVault.Models;
using StreamVault.Models.ViewModels;
using StreamVault.Services.Interfaces;

namespace StreamVault.Services;

public sealed class CatalogueService(StreamVaultDbContext db) : ICatalogueService
{
    async Task ICatalogueService.CreateAsync(CatalogueItem item)
    {
        db.CatalogueItems.Add(item);
        await db.SaveChangesAsync();
    }

    async Task ICatalogueService.DeleteAsync(Guid id)
    {
        var toDelete = await db.CatalogueItems
            .FirstOrDefaultAsync(item => item.Id == id);

        if (toDelete is null) return;

        db.CatalogueItems.Remove(toDelete);
        await db.SaveChangesAsync();
    }

    async Task<CatalogueItem?> ICatalogueService.GetByIdAsync(Guid id) =>
        await db.CatalogueItems.AsNoTracking()
            .Where(item => item.Id == id)
            .FirstOrDefaultAsync();

    async Task<CatalogueIndexViewModel> ICatalogueService.GetCatalogueItemsAsync(
        string? searchTerm,
        string? contentType)
    {
        IQueryable<CatalogueItem> query = db.CatalogueItems.AsNoTracking();

        if (!string.IsNullOrEmpty(searchTerm))
            query = query.Where(item => item.Title.Contains(searchTerm));

        if (!string.IsNullOrEmpty(contentType))
            query = contentType switch
            {
                "Movie" => query.OfType<Movie>(),
                "Series" => query.OfType<Series>(),
                "Audiobook" => query.OfType<Series>(),
                "Music Album" => query.OfType<MusicAlbum>(),
                _ => query
            };

        return new CatalogueIndexViewModel
        {
            Items = await query.ToListAsync(),
            TotalItemCount = await db.CatalogueItems.CountAsync(),
            MovieCount = await db.CatalogueItems.OfType<Movie>().CountAsync(),
            SeriesCount = await db.CatalogueItems.OfType<Series>().CountAsync(),
            AudiobookCount = await db.CatalogueItems.OfType<Audiobook>().CountAsync(),
            MusicAlbumCount = await db.CatalogueItems.OfType<MusicAlbum>().CountAsync()
        };
    }

    async Task ICatalogueService.UpdateAsync(CatalogueItem item)
    {
        db.CatalogueItems.Update(item);
        await db.SaveChangesAsync();
    }
}