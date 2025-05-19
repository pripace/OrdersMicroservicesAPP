using MediatR;
using Order.Application.DTOS;
using System.Collections.Generic;

namespace Order.Application.Features.Orders
{
    public class GetAllOrdersQuery : IRequest<List<OrderDto>> { }
}
