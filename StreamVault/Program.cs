using Microsoft.EntityFrameworkCore;
using StreamVault.Data;
using StreamVault.Services;
using StreamVault.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<StreamVaultDbContext>(options =>
    options.UseSqlite("Data Source=StreamVault.db"));

builder.Services.AddScoped<ICatalogueService, CatalogueService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Catalogue}/{action=Index}/{id?}")
    .WithStaticAssets();

DbManager.EnsureCreatedAndSeeded(app);

app.Run();
