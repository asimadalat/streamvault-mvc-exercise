using Microsoft.EntityFrameworkCore;
using StreamVault.Models;

namespace StreamVault.Data;

public sealed class StreamVaultDbContext(
    DbContextOptions<StreamVaultDbContext> options
) : DbContext(options)
{
    public DbSet<CatalogueItem> CatalogueItems { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Series> Series { get; set; }
    public DbSet<Audiobook> Audiobooks { get; set; }
    public DbSet<MusicAlbum> MusicAlbums { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<CatalogueItem>()
            .HasDiscriminator<string>("ContentType")
            .HasValue<Movie>("Movie")
            .HasValue<Series>("Series")
            .HasValue<Audiobook>("Audiobook")
            .HasValue<MusicAlbum>("MusicAlbum");
    }
}