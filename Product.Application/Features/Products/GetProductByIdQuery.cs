using MediatR;
using Product.Domain.Entities;

namespace Product.Application.Features.Products
{
    public class GetProductByIdQuery : IRequest<ProductEntity>
    {
        public int Id { get; set; }

    }
}
