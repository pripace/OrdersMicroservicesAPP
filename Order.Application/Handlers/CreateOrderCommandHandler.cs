using MediatR;
using Order.Application.Commands;
using Order.Application.Contracts;
using Order.Application.Interfaces;
using Order.Domain.Entities;

namespace Order.Application.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, OrderEntity>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public async Task<OrderEntity> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new OrderEntity
            {
                CustomerId = request.CustomerId,
                CustomerName = request.CustomerName,
                OrderDate = DateTime.UtcNow,
                OrderItems = new List<OrderItem>()
            };

            foreach (var itemDto in request.OrderItems)
            {
                var product = await _productRepository.GetByIdAsync(itemDto.ProductId);
                if (product == null)
                    throw new Exception("Producto no encontrado");

                int cantidadAComprar = Math.Min(itemDto.Quantity, product.Stock);

                if (cantidadAComprar == 0)
                    throw new Exception($"El producto '{product.Name}' no tiene stock disponible.");

                var orderItem = new OrderItem
                {
                    ProductId = itemDto.ProductId,
                    ProductName = product.Name,
                    UnitPrice = product.Price,
                    Quantity = cantidadAComprar
                };

                order.OrderItems.Add(orderItem);

                product.Stock -= cantidadAComprar;
                await _productRepository.UpdateProductAsync(product);
            }

            order.CalculateTotal();
            await _orderRepository.AddAsync(order);

            return order;
        }
    }
}

