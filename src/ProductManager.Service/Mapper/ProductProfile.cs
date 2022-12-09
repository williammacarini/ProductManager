using AutoMapper;
using ProductManager.Domain.Entities;
using ProductManager.Service.DTOs;

namespace ProductManager.Service.Mapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto, Product>()
                .ReverseMap();
        }
    }
}
