using MediatR;
using Order.Application.DTOS;
using Order.Domain.Entities;

namespace Order.Application.Commands
{
    public class CreateOrderCommand : IRequest<OrderEntity>
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }
}
