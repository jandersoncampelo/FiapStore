using FiapStore.Common.Repositories;
using FiapStore.Domain.Products;
using FiapStore.Domain.Customers;
using FiapStore.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using FiapStore.Domain.Baskets;

namespace FiapStore.Infrastructure;

public static class InfrastructureServiceExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IBasketRepository, BasketRepository>();

        return services;
    }
}
