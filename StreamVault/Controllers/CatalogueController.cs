using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StreamVault.Models;
using StreamVault.Models.ViewModels;
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

    [HttpGet]
    public async Task<IActionResult> CreateMovie() => View(new CreateMovieViewModel());

    [HttpGet]
    public async Task<IActionResult> CreateSeries() => View(new CreateSeriesViewModel());

    [HttpGet]
    public async Task<IActionResult> CreateAudiobook() => View(new CreateAudiobookViewModel());

    [HttpGet]
    public async Task<IActionResult> CreateMusicAlbum() => View(new CreateMusicAlbumViewModel());

    [HttpPost]
    public async Task<IActionResult> CreateMovie(CreateMovieViewModel viewModel)
    {
        if (!ModelState.IsValid) return View(viewModel);

        await catalogueService.CreateAsync(new Movie(viewModel));
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> CreateSeries(CreateSeriesViewModel viewModel)
    {
        if (!ModelState.IsValid) return View(viewModel);

        await catalogueService.CreateAsync(new Series(viewModel));
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAudiobook(CreateAudiobookViewModel viewModel)
    {
        if (!ModelState.IsValid) return View(viewModel);

        await catalogueService.CreateAsync(new Audiobook(viewModel));
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> CreateMusicAlbum(CreateMusicAlbumViewModel viewModel)
    {
        if (!ModelState.IsValid) return View(viewModel);

        await catalogueService.CreateAsync(new MusicAlbum(viewModel));
        return RedirectToAction(nameof(Index));
    }
}
