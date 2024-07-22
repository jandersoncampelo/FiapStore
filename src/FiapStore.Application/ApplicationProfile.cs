using AutoMapper;
using FiapStore.Application.Contracts.Category;
using FiapStore.Application.Contracts.Products;
using FiapStore.Application.Contracts.Customers;
using FiapStore.Domain.Products;
using FiapStore.Domain.Customers;
using FiapStore.Domain.Orders;
using FiapStore.Application.Contracts.Products.DTOs;
using FiapStore.Application.Contracts.Orders.DTOs;

namespace FiapStore.Application
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<CustomerCreateDto, Customer>().ReverseMap();
            CreateMap<CustomerUpdateDto, Customer>().ReverseMap();

            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom((src, dest) => src.Category.Name))
                .ReverseMap();
            CreateMap<ProductCreateDto, Product>().ReverseMap();
            CreateMap<ProductUpdateDto, Product>().ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<CategoryCreateDto, Category>().ReverseMap();
            CreateMap<CategoryUpdateDto, Category>().ReverseMap();

            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<OrderCreateDto, Order>().ReverseMap();
        }
    }
}
