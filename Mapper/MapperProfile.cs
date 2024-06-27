using AutoMapper;
using WebApiLessons.Dto;
using WebApiLessons.Models;

namespace WebApiLessons.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<ProductGroup, ProductGroupDto>().ReverseMap();
        }
    }
}