using FiapStore.Application.Contracts.Orders.Interfaces;
using FiapStore.Application.Contracts.Products;
using FiapStore.Application.Contracts.Products.Interfaces;
using FiapStore.Application.Contracts.Shoppers;
using FiapStore.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FiapStore.Application;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddTransient<IProductAppService, ProductAppService>();
        services.AddTransient<ICategoryAppService, CategoryAppService>();
        services.AddTransient<IShopperAppService, ShopperAppService>();
        services.AddTransient<IOrderAppService, OrderAppService>();

        return services;
    }
}
