using MediatR;
using Product.Domain.Entities;
using System.Collections.Generic;

namespace Product.Application.Features.Products
{
    public class GetAllProductsQuery : IRequest<IEnumerable<ProductEntity>>
    {
    }
}
