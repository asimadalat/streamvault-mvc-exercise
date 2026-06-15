using StreamVault.Models;

namespace StreamVault.Data;

public static class DbManager
{
    public static void EnsureCreatedAndSeeded(IApplicationBuilder applicationBuilder)
    {
        using var serviceScope = applicationBuilder.ApplicationServices.CreateScope();
        var dbContext = serviceScope.ServiceProvider
            .GetRequiredService<StreamVaultDbContext>();

        dbContext.Database.EnsureCreated();
        EnsureSeeded(dbContext);
    }

    private static void EnsureSeeded(StreamVaultDbContext db)
    {
        if (db.CatalogueItems.Any()) return;

        db.CatalogueItems.AddRange(
            new Movie { Title = "Inception", Description = "A thief steals corporate secrets through dream-sharing technology.", ReleaseDate = DateTime.Parse("2010-07-16"), Director = "Christopher Nolan", DurationMinutes = 148 },
            new Movie { Title = "The Matrix", Description = "A computer hacker learns about the true nature of his reality.", ReleaseDate = DateTime.Parse("1999-03-31"), Director = "Lana Wachowski", DurationMinutes = 136 },
            new Movie { Title = "Interstellar", Description = "A team of explorers travel through a wormhole in space.", ReleaseDate = DateTime.Parse("2014-11-07"), Director = "Christopher Nolan", DurationMinutes = 169 },
            new Movie { Title = "Parasite", Description = "Greed and class discrimination threaten a newly formed symbiotic relationship.", ReleaseDate = DateTime.Parse("2019-05-30"), Director = "Bong Joon Ho", DurationMinutes = 132 },
            new Movie { Title = "Spirited Away", Description = "A young girl wanders into a world ruled by gods, witches, and spirits.", ReleaseDate = DateTime.Parse("2001-07-20"), Director = "Hayao Miyazaki", DurationMinutes = 125 },

            new Series { Title = "Breaking Bad", Description = "A high school chemistry teacher turns to manufacturing methamphetamine.", ReleaseDate = DateTime.Parse("2008-01-20"), SeasonCount = 5, EpisodeCount = 62 },
            new Series { Title = "Stranger Things", Description = "When a young boy vanishes, a small town uncovers a mystery.", ReleaseDate = DateTime.Parse("2016-07-15"), SeasonCount = 4, EpisodeCount = 34 },
            new Series { Title = "Chernobyl", Description = "The dramatization of the 1986 nuclear accident.", ReleaseDate = DateTime.Parse("2019-05-06"), SeasonCount = 1, EpisodeCount = 5 },
            new Series { Title = "Succession", Description = "The Roy family is known for controlling the biggest media company.", ReleaseDate = DateTime.Parse("2018-06-03"), SeasonCount = 4, EpisodeCount = 39 },
            new Series { Title = "The Office (US)", Description = "A mockumentary on a group of typical office workers.", ReleaseDate = DateTime.Parse("2005-03-24"), SeasonCount = 9, EpisodeCount = 201 },

            new Audiobook { Title = "Dune", Description = "The sweeping epic space opera of Paul Atreides.", ReleaseDate = DateTime.Parse("1965-08-01"), Author = "Frank Herbert", Narrator = "Simon Vance", DurationMinutes = 1260 },
            new Audiobook { Title = "Project Hail Mary", Description = "A lone astronaut must save earth from an extinction-level event.", ReleaseDate = DateTime.Parse("2021-05-04"), Author = "Andy Weir", Narrator = "Ray Porter", DurationMinutes = 960 },
            new Audiobook { Title = "Atomic Habits", Description = "An easy way to build good habits and break bad ones.", ReleaseDate = DateTime.Parse("2018-10-16"), Author = "James Clear", Narrator = "James Clear", DurationMinutes = 320 },
            new Audiobook { Title = "The Hobbit", Description = "The classic prelude to the Lord of the Rings.", ReleaseDate = DateTime.Parse("1937-09-21"), Author = "J.R.R. Tolkien", Narrator = "Andy Serkis", DurationMinutes = 620 },
            new Audiobook { Title = "Educated", Description = "A memoir about a young girl who leaves her survivalist family.", ReleaseDate = DateTime.Parse("2018-02-20"), Author = "Tara Westover", Narrator = "Julia Whelan", DurationMinutes = 730 },

            new MusicAlbum { Title = "Abbey Road", Description = "The eleventh studio album by the English rock band.", ReleaseDate = DateTime.Parse("1969-09-26"), Artist = "The Beatles", TrackCount = 17, RecordLabel = "Apple Records" },
            new MusicAlbum { Title = "Dark Side of the Moon", Description = "The eighth studio album by the English rock band.", ReleaseDate = DateTime.Parse("1973-03-01"), Artist = "Pink Floyd", TrackCount = 10, RecordLabel = "Harvest Records" },
            new MusicAlbum { Title = "Random Access Memories", Description = "A tribute to late 1970s and early 1980s American music.", ReleaseDate = DateTime.Parse("2013-05-17"), Artist = "Daft Punk", TrackCount = 13, RecordLabel = "Columbia Records" },
            new MusicAlbum { Title = "Rumours", Description = "The eleventh studio album by British-American rock band.", ReleaseDate = DateTime.Parse("1977-02-04"), Artist = "Fleetwood Mac", TrackCount = 11, RecordLabel = "Warner Bros." },
            new MusicAlbum { Title = "Thriller", Description = "The sixth studio album by the American singer.", ReleaseDate = DateTime.Parse("1982-11-30"), Artist = "Michael Jackson", TrackCount = 9, RecordLabel = "Epic Records" }
        );

        db.SaveChanges();
    }
}