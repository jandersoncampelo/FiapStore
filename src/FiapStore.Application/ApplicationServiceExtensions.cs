using FiapStore.Application.Contracts.Category;
using FiapStore.Application.Contracts.Products;
using FiapStore.Application.Contracts.Customers;
using FiapStore.Application.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using FiapStore.Application.Contracts.Basket;

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

        return services;
    }
}
