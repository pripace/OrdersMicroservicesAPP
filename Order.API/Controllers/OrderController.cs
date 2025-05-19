using MediatR;
using Microsoft.AspNetCore.Mvc;
using Order.Application.Commands;
using Order.Application.DTOS;
using Order.Domain.Entities;
using Order.Application.Features.Orders;
using AutoMapper;

namespace Order.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public OrderController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<OrderEntity>> Create([FromBody] CreateOrderDto createOrderDto)
        {
            var command = new CreateOrderCommand
            {
                CustomerId = createOrderDto.CustomerId,
                CustomerName = createOrderDto.CustomerName,
                OrderItems = _mapper.Map<List<OrderItemDto>>(createOrderDto.OrderItems)
            };

            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderEntity>> GetById(int id)
        {
            var order = await _mediator.Send(new GetOrderByIdQuery(id));

            if (order == null)
                return NotFound();

            return Ok(order);
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderDto>>> GetAll()
        {
            var orders = await _mediator.Send(new GetAllOrdersQuery());
            return Ok(orders);
        }

    }
}
