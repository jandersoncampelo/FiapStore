using FiapStore.Common.Repositories;
using FiapStore.Domain.Baskets;
using FiapStore.Domain.Customers;
using FiapStore.Domain.Orders;
using FiapStore.Domain.Products;
using FiapStore.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

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
        services.AddScoped<IOrderRepository, OrderRepository>();

        return services;
    }
}
