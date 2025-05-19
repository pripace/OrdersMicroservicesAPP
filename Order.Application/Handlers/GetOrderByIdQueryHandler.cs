using AutoMapper;
using MediatR;
using Order.Application.DTOS;
using Order.Application.Features.Orders;
using Order.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Order.Application.Handlers
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrderByIdQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.OrderId);
            if (order == null)
            {
                throw new Exception("No hay órdenes");
            }

            return _mapper.Map<OrderDto>(order);
        }
    }
}

