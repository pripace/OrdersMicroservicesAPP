using AutoMapper;
using Order.Application.DTOS;
using Order.Domain.Entities;

namespace Order.Application.Profiles
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<CreateOrderItemDto, OrderItemDto>();

            CreateMap<CreateOrderDto, OrderEntity>();

            CreateMap<OrderEntity, OrderDto>();
        }
    }
}
