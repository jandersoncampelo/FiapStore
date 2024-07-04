using Microsoft.EntityFrameworkCore;

namespace FiapStore.Infrastructure.Data;

public class FiapDbContext(DbContextOptions<FiapDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FiapDbContext).Assembly);
    }
}