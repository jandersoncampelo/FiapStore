using FiapStore.Application.Contracts.Basket;
using FiapStore.Application.Contracts.Category;
using FiapStore.Application.Contracts.Customers;
using FiapStore.Application.Contracts.Orders.Interfaces;
using FiapStore.Application.Contracts.Products;
using FiapStore.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FiapStore.Application;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ApplicationProfile));

        services.AddTransient<IProductAppService, ProductAppService>();
        services.AddTransient<ICustomerAppService, CustomerAppService>();
        services.AddTransient<ICategoryAppService, CategoryAppService>();
        services.AddTransient<IBasketAppService, BasketAppService>();
        services.AddTransient<IOrderAppService, OrderAppService>();

        return services;
    }
}
