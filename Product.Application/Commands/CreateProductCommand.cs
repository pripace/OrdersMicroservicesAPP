using MediatR;
using Product.Domain.Entities;

namespace Product.Application.Commands
{
    public class CreateProductCommand : IRequest<ProductEntity>
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
