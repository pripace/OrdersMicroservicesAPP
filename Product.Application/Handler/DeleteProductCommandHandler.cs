using MediatR;
using Product.Application.Commands;
using Product.Application.Interfaces;

namespace Product.Application.Handlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);
            if (product == null)
            {
                throw new Exception("Product not found.");
            }

            await _productRepository.DeleteAsync(request.Id);
            return Unit.Value;  
        }
    }
}



