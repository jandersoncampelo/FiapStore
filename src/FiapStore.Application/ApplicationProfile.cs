using AutoMapper;
using FiapStore.Application.Contracts.Category;
using FiapStore.Application.Contracts.Products;
using FiapStore.Application.Contracts.Shoppers;
using FiapStore.Domain.Products;
using FiapStore.Domain.Shoppers;

namespace FiapStore.Application
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Shopper, ShopperDto>().ReverseMap();
            CreateMap<ShopperCreateDto, Shopper>().ReverseMap();
            CreateMap<ShopperUpdateDto, Shopper>().ReverseMap();

            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<ProductCreateDto, Product>().ReverseMap();
            CreateMap<ProductUpdateDto, Product>().ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<CategoryCreateDto, Category>().ReverseMap();
            CreateMap<CategoryUpdateDto, Category>().ReverseMap();
        }
    }
}
