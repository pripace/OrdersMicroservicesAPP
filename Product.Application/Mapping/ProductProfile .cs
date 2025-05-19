using AutoMapper;
using Product.Domain.Entities;
using Product.Application.DTOS;

namespace Product.Application.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductEntity, ProductDto>().ReverseMap();
        }
    }
}
