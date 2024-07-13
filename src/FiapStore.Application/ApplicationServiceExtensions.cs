using FiapStore.Application.Contracts.Category;
using FiapStore.Application.Contracts.Products;
using FiapStore.Application.Contracts.Shoppers;
using FiapStore.Application.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace FiapStore.Application;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ApplicationProfile));

        services.AddTransient<IProductAppService, ProductAppService>();
        services.AddTransient<IShopperAppService, ShopperAppService>();
        services.AddTransient<ICategoryAppService, CategoryAppService>();

        return services;
    }
}
