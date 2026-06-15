namespace StreamVault.Data;

public static class DbManager
{
    public static void EnsureCreated(IApplicationBuilder applicationBuilder)
    {
        using var serviceScope = applicationBuilder.ApplicationServices.CreateScope();
        var dbContext = serviceScope.ServiceProvider
            .GetRequiredService<StreamVaultDbContext>();

        dbContext.Database.EnsureCreated();
    }
}