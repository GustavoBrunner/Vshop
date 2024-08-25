using AutoMapper;
using VShop.ProductAPI.Models;

namespace VShop.ProductAPI.DTOs.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile() 
    {
        CreateMap<ProductDto, Product>();
        CreateMap<Product, ProductDto>()
            .ForMember(p => p.CategoryName, 
            map => map.MapFrom(c => c.Name));
        CreateMap<Category, CategoryDto>();
        CreateMap<CategoryDto, Category>();
    }
}
