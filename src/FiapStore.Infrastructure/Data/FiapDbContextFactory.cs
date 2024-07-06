using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace FiapStore.Infrastructure.Data;

public class FiapDbContextFactory : IDesignTimeDbContextFactory<FiapDbContext>
{
    public FiapDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<FiapDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new FiapDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../FiapStore.API/"))
            .AddJsonFile("appsettings.json", optional: false);


        //.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        //.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true)
        //.AddEnvironmentVariables();

        return builder.Build();
    }
}
