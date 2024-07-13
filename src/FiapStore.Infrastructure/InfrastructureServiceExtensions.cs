using FiapStore.Common.Repositories;
using FiapStore.Domain.Products;
using FiapStore.Domain.Shoppers;
using FiapStore.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FiapStore.Infrastructure;

public static class InfrastructureServiceExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IShopperRepository, ShopperRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();

        return services;
    }
}
