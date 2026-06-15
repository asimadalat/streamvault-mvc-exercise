using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StreamVault.Models;
using StreamVault.Services.Interfaces;

namespace StreamVault.Controllers;

public sealed class CatalogueController(ICatalogueService catalogueService) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index(
        [FromQuery] string? searchTerm = null, [FromQuery] string? contentType = null)
    {
        var filteredCatalogueItems = await catalogueService
            .GetCatalogueItemsAsync(searchTerm?.Trim(), contentType);

        return View(filteredCatalogueItems);
    }
}
