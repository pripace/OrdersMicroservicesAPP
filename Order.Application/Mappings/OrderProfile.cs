using AutoMapper;
using Order.Application.DTOS;
using Order.Domain.Entities;

namespace Order.Application.Mappings
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderEntity, OrderDto>();

            CreateMap<OrderItem, OrderItemDto>();
        }
    }
}
