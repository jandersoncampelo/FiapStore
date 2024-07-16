using AutoMapper;
using FiapStore.Application.Contracts.Category;
using FiapStore.Application.Contracts.Products;
using FiapStore.Application.Contracts.Customers;
using FiapStore.Domain.Products;
using FiapStore.Domain.Customers;

namespace FiapStore.Application
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<CustomerCreateDto, Customer>().ReverseMap();
            CreateMap<CustomerUpdateDto, Customer>().ReverseMap();

            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<ProductCreateDto, Product>().ReverseMap();
            CreateMap<ProductUpdateDto, Product>().ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<CategoryCreateDto, Category>().ReverseMap();
            CreateMap<CategoryUpdateDto, Category>().ReverseMap();
        }
    }
}
