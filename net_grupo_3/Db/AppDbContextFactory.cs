using Microsoft.Extensions.Configuration;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // crear configuración mysql
        string url = builder.Configuration.GetConnectionString("DbContext");

        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseMySql(url, ServerVersion.AutoDetect(url))
            .Options;

        return new AppDbContext(options);
    }
}