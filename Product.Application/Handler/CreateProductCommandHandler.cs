using MediatR;
using Product.Domain.Entities;
using Product.Application.Interfaces;
using Product.Application.Commands;

namespace Product.Application.Handler
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductEntity>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductEntity> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new ProductEntity
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Stock = request.Stock
            };

            await _productRepository.AddAsync(product);
            return product;
        }
    }
}
